#include "PlayspaceMover.hpp"

vrinputemulator::VRInputEmulator g_inputEmulator;
struct PlayspaceMover::Options g_options;
LogProc g_logProc = NULL;
UpdateProc g_updateProc = NULL;
bool g_requestExit = false;
