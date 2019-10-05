#pragma once

namespace PlayspaceMover
{
    class Devices {
    public:
        vr::TrackedDevicePose_t pose[vr::k_unMaxTrackedDeviceCount];
        glm::vec3 position[vr::k_unMaxTrackedDeviceCount];
        glm::vec3 lastPosition[vr::k_unMaxTrackedDeviceCount];
        glm::vec3 baseOffset[vr::k_unMaxTrackedDeviceCount];

        Devices() {}

        void updateBaseOffsets();
        void updatePositions();

        static uint32_t findHMD();
        static void setVirtualDevicePosition(uint32_t id, glm::vec3 pos, glm::quat rot);
        static vr::TrackedDeviceIndex_t getLeftButtons(vr::VRControllerState_t& leftButtons);
        static vr::TrackedDeviceIndex_t getRightButtons(vr::VRControllerState_t& rightButtons);
    };
}
