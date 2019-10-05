#pragma once

namespace PlayspaceMover
{
    class Runtime
    {
        Trackers trackers;
        Devices devices;
        vr::IVRSystem* VRSystem;
        glm::mat4 offset, lastOffset;

        void updateOffset(float deltaTime);
        void updateTrackers(float deltaTime);
        void movePlayspace();

    public:
        Runtime();
        void init();
        unsigned long loop();
    };

    DWORD runtimeThread(void* arguments);
}
