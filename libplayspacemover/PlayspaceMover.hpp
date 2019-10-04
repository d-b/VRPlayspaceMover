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

#include "Options.hpp"
#include "Trackers.hpp"
#include "Devices.hpp"
#include "Globals.hpp"