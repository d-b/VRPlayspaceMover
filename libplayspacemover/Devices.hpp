#pragma once

namespace PlayspaceMover
{
	class Devices {
	public:
		vr::TrackedDevicePose_t pose[vr::k_unMaxTrackedDeviceCount];
		glm::vec3 position[vr::k_unMaxTrackedDeviceCount];
		glm::vec3 lastPosition[vr::k_unMaxTrackedDeviceCount];
		glm::vec3 baseOffset[vr::k_unMaxTrackedDeviceCount];

		Devices() { updateBaseOffsets();  }

		void updateBaseOffsets();
		void updatePositions();
	};
}
