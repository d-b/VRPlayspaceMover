#pragma once

enum ELogLevels { LOG_Info = 0, LOG_Warning = 1, LOG_Error = 2 };
typedef void(*LogProc)(uint64_t level, const wchar_t* message);
typedef PlayspaceMover::TrackerState(*UpdateProc)(PlayspaceMover::PlayState state);

extern vrinputemulator::VRInputEmulator g_inputEmulator;
extern PlayspaceMover::Options g_options;
extern LogProc g_logProc;
extern UpdateProc g_updateProc;
extern bool g_requestExit;
