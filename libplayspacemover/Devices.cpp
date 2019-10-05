#include "PlayspaceMover.hpp"

namespace PlayspaceMover
{
    void Devices::updateBaseOffsets()
    {
        for (uint32_t deviceIndex = 0; deviceIndex < vr::k_unMaxTrackedDeviceCount; deviceIndex++) {
            if (!vr::VRSystem()->IsTrackedDeviceConnected(deviceIndex)) {
                baseOffset[deviceIndex] = glm::vec3(0);
                continue;
            }

            vrinputemulator::DeviceOffsets data;
            try {
                g_inputEmulator.getDeviceOffsets(deviceIndex, data);
                glm::vec3 offset;
                offset.x = (float)data.worldFromDriverTranslationOffset.v[0];
                offset.y = (float)data.worldFromDriverTranslationOffset.v[1];
                offset.z = (float)data.worldFromDriverTranslationOffset.v[2];
                baseOffset[deviceIndex] = offset;
            }
            catch (vrinputemulator::vrinputemulator_notfound e) {
                glm::vec3 offset;
                offset.x = 0;
                offset.y = 0;
                offset.z = 0;
                baseOffset[deviceIndex] = offset;
            }
        }
    }

    void Devices::updatePositions()
    {
        float fSecondsSinceLastVsync; vr::VRSystem()->GetTimeSinceLastVsync(&fSecondsSinceLastVsync, NULL);
        float fDisplayFrequency = vr::VRSystem()->GetFloatTrackedDeviceProperty(vr::k_unTrackedDeviceIndex_Hmd, vr::Prop_DisplayFrequency_Float);
        float fFrameDuration = 1.f / fDisplayFrequency;
        float fVsyncToPhotons = vr::VRSystem()->GetFloatTrackedDeviceProperty(vr::k_unTrackedDeviceIndex_Hmd, vr::Prop_SecondsFromVsyncToPhotons_Float);
        float fPredictedSecondsFromNow = fFrameDuration - fSecondsSinceLastVsync + fVsyncToPhotons;
        vr::VRSystem()->GetDeviceToAbsoluteTrackingPose(vr::TrackingUniverseRawAndUncalibrated, fPredictedSecondsFromNow, pose, vr::k_unMaxTrackedDeviceCount);

        for (uint32_t deviceIndex = 0; deviceIndex < vr::k_unMaxTrackedDeviceCount; deviceIndex++) {
            if (!vr::VRSystem()->IsTrackedDeviceConnected(deviceIndex)) continue;
            vr::TrackedDevicePose_t* p = pose + deviceIndex;
            vr::HmdMatrix34_t* mat = &(p->mDeviceToAbsoluteTracking);
            if (p->bPoseIsValid && p->bDeviceIsConnected) {
                lastPosition[deviceIndex] = position[deviceIndex];
                position[deviceIndex] = glm::vec3(mat->m[0][3], mat->m[1][3], mat->m[2][3]);
            }
        }
    }

    uint32_t Devices::findHMD() {
        uint32_t HMDID = vr::k_unTrackedDeviceIndexInvalid;
        for (uint32_t deviceIndex = 0; deviceIndex < vr::k_unMaxTrackedDeviceCount; deviceIndex++) {
            if (vr::VRSystem()->IsTrackedDeviceConnected(deviceIndex) &&
                vr::VRSystem()->GetTrackedDeviceClass(deviceIndex) == vr::TrackedDeviceClass_HMD) {
                HMDID = deviceIndex;
                break;
            }
        }
        return HMDID;
    }

    void Devices::setVirtualDevicePosition(uint32_t id, glm::vec3 pos, glm::quat rot)
    {
        vr::DriverPose_t pose = g_inputEmulator.getVirtualDevicePose(id);
        pose.vecPosition[0] = pos.x;
        pose.vecPosition[1] = pos.y;
        pose.vecPosition[2] = pos.z;
        pose.poseIsValid = true;
        pose.deviceIsConnected = true;
        pose.result = vr::TrackingResult_Running_OK;
        pose.qRotation.w = rot.w;
        pose.qRotation.x = rot.x;
        pose.qRotation.y = rot.y;
        pose.qRotation.z = rot.z;
        g_inputEmulator.setVirtualDevicePose(id, pose, false);
    }

    vr::TrackedDeviceIndex_t Devices::getLeftButtons(vr::VRControllerState_t& leftButtons)
    {
        auto deviceId = vr::VRSystem()->GetTrackedDeviceIndexForControllerRole(vr::TrackedControllerRole_LeftHand);
        if (deviceId != vr::k_unTrackedDeviceIndexInvalid)
            vr::VRSystem()->GetControllerState(deviceId, &leftButtons, sizeof(vr::VRControllerState_t));
        return deviceId;
    }

    vr::TrackedDeviceIndex_t Devices::getRightButtons(vr::VRControllerState_t& rightButtons)
    {
        auto deviceId = vr::VRSystem()->GetTrackedDeviceIndexForControllerRole(vr::TrackedControllerRole_RightHand);
        if (deviceId != vr::k_unTrackedDeviceIndexInvalid)
            vr::VRSystem()->GetControllerState(deviceId, &rightButtons, sizeof(vr::VRControllerState_t));
        return deviceId;
    }
}
