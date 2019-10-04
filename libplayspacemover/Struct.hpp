#pragma once

namespace PlayspaceMover
{
#pragma pack(push, 1)
	struct Options {
		uint64_t leftButtonMask = 130;
		uint64_t rightButtonMask = 130;
		uint64_t leftTogglePhysicsMask = 0;
		uint64_t rightTogglePhysicsMask = 0;
		uint64_t resetButtonMask = 0;
		float bodyHeight = 2;
	};

	struct DeviceState {
		glm::vec3 pos;
		glm::quat rot;
	};

	struct PlayState {
		float deltaTime;
		DeviceState hmd;
		DeviceState hip;
		DeviceState lfoot;
		DeviceState rfoot;
	};

	struct TrackerState {
		DeviceState hip;
		DeviceState lfoot;
		DeviceState rfoot;
	};
#pragma pack(pop)
}
