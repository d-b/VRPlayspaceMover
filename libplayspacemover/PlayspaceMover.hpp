#pragma once

#include <iostream>
#include <algorithm>
#include <string>
#include <thread>
#include <vector>
#include <unordered_set>
#include <unordered_map>
#include <openvr.h>
#include <vrinputemulator.h>
#define GLM_FORCE_SWIZZLE
#define GLM_ENABLE_EXPERIMENTAL
#include <glm/glm.hpp>
#include <glm/gtc/quaternion.hpp> 
#include <glm/gtx/quaternion.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <csignal>

#ifdef _WIN32
#include <Windows.h>
#endif

#include "Struct.hpp"
#include "Trackers.hpp"
#include "Devices.hpp"
#include "Globals.hpp"
#include "Runtime.hpp"

#ifdef PLAYSPACEMOVER_EXPORTS
#define PLAYSPACEMOVER_API extern "C" __declspec(dllexport) 
#else
#define PLAYSPACEMOVER_API __declspec(dllimport)
#endif

PLAYSPACEMOVER_API uint64_t Init(LogProc logProc, UpdateProc updateProc, PlayspaceMover::Options options);
PLAYSPACEMOVER_API uint64_t Configure(PlayspaceMover::Options options);
PLAYSPACEMOVER_API uint64_t Exit();

namespace PlayspaceMover
{
	void log(uint64_t level, const wchar_t* message);
	TrackerState update(PlayState state);
	Options configuration();
}
