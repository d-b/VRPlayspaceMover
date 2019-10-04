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
}
