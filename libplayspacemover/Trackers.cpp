#include "PlayspaceMover.hpp"

namespace PlayspaceMover
{
	Trackers::~Trackers()
	{
		std::for_each(virtualDeviceMap.begin(), virtualDeviceMap.end(), [&](std::pair<std::string, uint32_t> item) {
			destroyTracker(item.second);
		});
	}

	void Trackers::addTrackers(std::vector<std::string> serials)
	{
		for (uint32_t i = 0; i < g_inputEmulator.getVirtualDeviceCount(); i++) {
			vr::DriverPose_t pose = g_inputEmulator.getVirtualDevicePose(i);
			if (pose.deviceIsConnected == true || pose.result != vr::TrackingResult_Uninitialized || pose.poseIsValid == true) continue;
			
			auto info = g_inputEmulator.getVirtualDeviceInfo(i);
			if (std::find(serials.begin(), serials.end(), info.deviceSerial) != serials.end())
				virtualDeviceMap[info.deviceSerial] = info.virtualDeviceId;
		}

		std::for_each(serials.begin(), serials.end(), [&](const std::string& serial) {
			if (virtualDeviceMap.find(serial) == virtualDeviceMap.end())
				virtualDeviceMap[serial] = createTracker(serial);
		});
	}
	
	void Trackers::refreshDevices()
	{
		if (virtualDeviceSet.size() != g_inputEmulator.getVirtualDeviceCount()) {
			for (uint32_t deviceIndex = 0; deviceIndex < vr::k_unMaxTrackedDeviceCount; deviceIndex++) {
				try {
					auto info = g_inputEmulator.getVirtualDeviceInfo(deviceIndex);
					if (info.openvrDeviceId < vr::k_unMaxTrackedDeviceCount)
						virtualDeviceSet.emplace(info.openvrDeviceId);
				}
				catch (vrinputemulator::vrinputemulator_exception const&) {}
			}
		}
	}

	bool Trackers::isTracker(uint32_t deviceIndex) const
	{
		return virtualDeviceSet.find(deviceIndex) != virtualDeviceSet.end();
	}
	
	uint32_t Trackers::getTracker(const std::string& name) const
	{
		auto it = virtualDeviceMap.find(name);
		if (it == virtualDeviceMap.end()) return -1;
		else return it->second;
	}

	uint32_t Trackers::createTracker(const std::string& serial)
	{
		uint32_t id = g_inputEmulator.addVirtualDevice(vrinputemulator::VirtualDeviceType::TrackedController, serial, false);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_TrackingSystemName_String, "lighthouse");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_ModelNumber_String, "Vive Controller MV");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_RenderModelName_String, "vr_controller_vive_1_5");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_WillDriftInYaw_Bool, false);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_ManufacturerName_String, "HTC");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_TrackingFirmwareVersion_String, "1465809478 htcvrsoftware@firmware-win32 2016-06-13 FPGA 1.6/0/0 VRC 1465809477 Radio 1466630404");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_HardwareRevision_String, "product 129 rev 1.5.0 lot 2000/0/0 0");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_DeviceIsWireless_Bool, true);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_HardwareRevision_Uint64, (uint64_t)2164327680);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_FirmwareVersion_Uint64, (uint64_t)1465809478);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_DeviceClass_Int32, 3);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_SupportedButtons_Uint64, (uint64_t)12884901895);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_Axis0Type_Int32, 1);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_Axis1Type_Int32, 3);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_Axis2Type_Int32, 0);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_Axis3Type_Int32, 0);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_Axis4Type_Int32, 0);
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_IconPathName_String, "icons");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_NamedIconPathDeviceOff_String, "{htc}controller_status_off.png");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_NamedIconPathDeviceSearching_String, "{htc}controller_status_searching.gif");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_NamedIconPathDeviceSearchingAlert_String, "{htc}controller_status_alert.gif");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_NamedIconPathDeviceReady_String, "{htc}controller_status_ready.png");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_NamedIconPathDeviceNotReady_String, "{htc}controller_status_error.png");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_NamedIconPathDeviceStandby_String, "{htc}controller_status_standby.png");
		g_inputEmulator.setVirtualDeviceProperty(id, vr::ETrackedDeviceProperty::Prop_NamedIconPathDeviceAlertLow_String, "{htc}controller_status_ready_low.png");
		g_inputEmulator.publishVirtualDevice(id);
		return id;
	}

	void Trackers::destroyTracker(uint32_t id)
	{
		auto pose = g_inputEmulator.getVirtualDevicePose(id);
		pose.deviceIsConnected = false;
		pose.result = vr::TrackingResult_Uninitialized;
		pose.poseIsValid = false;
		g_inputEmulator.setVirtualDevicePose(id, pose, false);
	}
}
