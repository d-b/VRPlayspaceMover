#include "PlayspaceMover.hpp"

namespace PlayspaceMover
{
    Runtime::Runtime()
        : offset(glm::mat4x4(1)), lastOffset(glm::mat4x4(1))
    {}

    void Runtime::init()
    {
        vr::EVRInitError error = vr::VRInitError_Compositor_Failed;
        log(LOG_Info, L"Looking for SteamVR... ");
        while (error != vr::VRInitError_None) {
            VRSystem = vr::VR_Init(&error, vr::VRApplication_Overlay);
            if (error != vr::VRInitError_None) {
                std::wstringstream stream;
                stream << L"\nFailed due to reason " << VR_GetVRInitErrorAsSymbol(error) << "\n";
                log(LOG_Error, stream.str().c_str());
                log(LOG_Info, L"Trying again in a few seconds... ");
                std::this_thread::sleep_for(std::chrono::seconds(4));
            }
        }

        log(LOG_Info, L"Success!\n");
        log(LOG_Info, L"Looking for VR Input Emulator... ");
        for (;;) {
            try {
                g_inputEmulator.connect(); break;
            }
            catch (vrinputemulator::vrinputemulator_connectionerror e) {
                log(LOG_Error, L"\nFailed to connect to open vr input emulator, ensure you've installed it. If you have, try running this fix: https://drive.google.com/open?id=1Gn3IOm6GbkINplbEenu0zTr3DkB1E8Hc\n");
                std::this_thread::sleep_for(std::chrono::seconds(4));
                continue;
            }
        }
        log(LOG_Info, L"Success!\n");

        devices.updateBaseOffsets();
        trackers.addTrackers({ "playspacemover_hip", "playspacemover_lfoot", "playspacemover_rfoot" });
    }

    unsigned long Runtime::loop()
    {
        int currentFrame = 0, numFramePresents = 0;
        auto lastTime = std::chrono::high_resolution_clock::now();

        while (!g_requestExit) {
            if (vr::VRCompositor() == NULL) {
                std::this_thread::sleep_for(std::chrono::microseconds(1111)); continue;
            }

            vr::Compositor_FrameTiming timing;
            timing.m_nSize = sizeof(vr::Compositor_FrameTiming);
            bool hasFrame = vr::VRCompositor()->GetFrameTiming(&timing, 0);
            auto currentTime = std::chrono::high_resolution_clock::now();
            float deltaTime = std::chrono::duration_cast<std::chrono::duration<float>>(currentTime - lastTime).count();

            if (!hasFrame || (currentFrame == timing.m_nFrameIndex && timing.m_nNumFramePresents == numFramePresents)) {
                std::this_thread::sleep_for(std::chrono::microseconds(1111)); continue;
            }

            currentFrame = timing.m_nFrameIndex;
            numFramePresents = timing.m_nNumFramePresents;
            lastTime = currentTime;

            trackers.refreshDevices();
            devices.updatePositions();
            updateOffset(deltaTime);
            updateTrackers(deltaTime);
            movePlayspace();

            // Sleep for just under 1/90th of a second, so that maybe the next frame will be available.
            std::this_thread::sleep_for(std::chrono::microseconds(10000));
        }

        return 0;
    }

    static bool checkAll(uint64_t button, uint64_t mask) {
        bool ret = mask ? 1 : 0;
        for (int i = 0; i < 64; i++) {
            if (mask >> i & 1) {
                ret = ret && (button & (mask & ((uint64_t)1 << i)));
            }
        }
        return ret;
    }

    void Runtime::updateOffset(float deltaTime) {
        Options conf = configuration();
        vr::VRControllerState_t leftButtons = { 0 }, rightButtons = { 0 };
        glm::vec3 delta = glm::vec3(0, 0, 0);
        float count = 0.f;

        auto leftId = Devices::getLeftButtons(leftButtons);
        if (leftId != vr::k_unTrackedDeviceIndexInvalid && leftButtons.ulButtonPressed & conf.leftButtonMask) {
            delta += devices.position[leftId] - devices.lastPosition[leftId]; count++;
        }

        auto rightId = Devices::getRightButtons(rightButtons);
        if (rightId != vr::k_unTrackedDeviceIndexInvalid && rightButtons.ulButtonPressed & conf.rightButtonMask) {
            delta += devices.position[rightId] - devices.lastPosition[rightId]; count++;
        }

        if (count) delta /= count;
        lastOffset = offset;
        offset = glm::translate(offset, -delta);

        if (checkAll(leftButtons.ulButtonPressed, conf.resetButtonMask) &&
            checkAll(rightButtons.ulButtonPressed, conf.resetButtonMask)) offset = glm::mat4(1);
    }

    void Runtime::updateTrackers(float deltaTime) {
        uint32_t HMDID = Devices::findHMD();
        if (HMDID == vr::k_unTrackedDeviceIndexInvalid) return;

        vr::TrackedDevicePose_t* hmdPose = devices.pose + HMDID;
        glm::mat3x4* hmdMat = (glm::mat3x4*)&(hmdPose->mDeviceToAbsoluteTracking);
        glm::mat3x3 hmdRotMat = glm::mat3x3(*hmdMat);
        if (hmdPose->bPoseIsValid && hmdPose->bDeviceIsConnected) {
            Options conf = configuration();
            vr::VRControllerState_t leftButtons = { 0 }, rightButtons = { 0 };
            Devices::getLeftButtons(leftButtons);
            Devices::getRightButtons(rightButtons);

            PlayState playState;
            playState.deltaTime = deltaTime;
            playState.unlockPlayer =
                checkAll(leftButtons.ulButtonPressed, conf.unlockButtonMask) &&
                checkAll(rightButtons.ulButtonPressed, conf.unlockButtonMask);
            playState.hmd.pos = (glm::inverse(offset)*glm::vec4(devices.position[HMDID], 1)).xyz();
            playState.hmd.rot = glm::inverse(glm::quat_cast(hmdRotMat));
            TrackerState trackerState = PlayspaceMover::update(playState);

            Devices::setVirtualDevicePosition(trackers["playspacemover_hip"], trackerState.hip.pos, trackerState.hip.rot);
            Devices::setVirtualDevicePosition(trackers["playspacemover_lfoot"], trackerState.lfoot.pos, trackerState.lfoot.rot);
            Devices::setVirtualDevicePosition(trackers["playspacemover_rfoot"], trackerState.rfoot.pos, trackerState.rfoot.rot);
        }
    }

    void Runtime::movePlayspace() {
        for (uint32_t deviceIndex = 0; deviceIndex < vr::k_unMaxTrackedDeviceCount; deviceIndex++) {
            if (!vr::VRSystem()->IsTrackedDeviceConnected(deviceIndex)) continue;

            glm::vec3 oldpos = (glm::inverse(lastOffset)*glm::vec4(devices.position[deviceIndex], 1.f)).xyz();
            glm::vec3 newpos = (offset * glm::vec4(oldpos, 1.f)).xyz();
            devices.position[deviceIndex] = newpos;
            glm::vec3 delta = devices.baseOffset[deviceIndex];

            // Virtual devices need to be moved half as much, don't ask me why
            delta += (newpos - oldpos) * (trackers.isTracker(deviceIndex) ? 0.5f : 1.0f);

            vr::HmdVector3d_t copy;
            copy.v[0] = delta.x;
            copy.v[1] = delta.y;
            copy.v[2] = delta.z;
            g_inputEmulator.enableDeviceOffsets(deviceIndex, true, false);
            g_inputEmulator.setWorldFromDriverTranslationOffset(deviceIndex, copy, false);
        }
    }

    static DWORD runtimeMain() {
        Runtime runtime;
        runtime.init();
        return runtime.loop();
    }

    DWORD runtimeThread(void* arguments) {
        DWORD result = runtimeMain();
        g_inputEmulator.disconnect();
        return result;
    }
}
