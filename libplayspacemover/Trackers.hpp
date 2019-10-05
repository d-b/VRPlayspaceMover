#pragma once

namespace PlayspaceMover
{
	class Trackers {
		std::unordered_set<uint32_t> virtualDeviceSet;
		std::unordered_map<std::string, uint32_t> virtualDeviceMap;

		static uint32_t createTracker(const std::string& serial);
		static void destroyTracker(uint32_t id);

	public:
		Trackers() {}
		Trackers(std::vector<std::string> serials) { addTrackers(serials); }
		uint32_t operator[](const std::string& name) { return getTracker(name); }
		virtual ~Trackers();

		void addTrackers(std::vector<std::string> serials);
		void refreshDevices();

		bool isTracker(uint32_t id) const;
		uint32_t getTracker(const std::string& name) const;
	};
}
