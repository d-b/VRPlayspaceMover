#pragma once

namespace PlayspaceMover
{
#pragma pack(push, 1)
	struct Options {
		uint64_t leftButtonMask = 130;
		uint64_t rightButtonMask = 130;
		uint64_t resetButtonMask = 0;
		uint64_t rotateButtonMask = 0;
	};

	struct DeviceState {
		glm::vec3 pos;
		glm::quat rot;
	};

	struct PlayState {
		float deltaTime;
		uint64_t rotatePlayer;
		DeviceState hmd;
	};

	struct TrackerState {
		DeviceState hip;
		DeviceState lfoot;
		DeviceState rfoot;
	};
#pragma pack(pop)
}
