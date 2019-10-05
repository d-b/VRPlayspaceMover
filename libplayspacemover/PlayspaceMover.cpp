#include "PlayspaceMover.hpp"

static CRITICAL_SECTION m_libraryLock;
static CRITICAL_SECTION m_configLock;
static HANDLE m_libraryThread = NULL;

uint64_t Init(LogProc logProc, UpdateProc updateProc, PlayspaceMover::Options options)
{
    EnterCriticalSection(&m_libraryLock);
    if (!m_libraryThread) {
        g_requestExit = false;
        g_logProc = logProc;
        g_updateProc = updateProc;
        g_options = options;
        m_libraryThread = CreateThread(NULL, 0, PlayspaceMover::runtimeThread, NULL, 0, NULL);
    }
    LeaveCriticalSection(&m_libraryLock);
    return 0;
}

uint64_t Configure(PlayspaceMover::Options options)
{
    EnterCriticalSection(&m_configLock);
    g_options = options;
    LeaveCriticalSection(&m_configLock);
    return 0;
}

uint64_t Exit()
{
    EnterCriticalSection(&m_libraryLock);
    if (m_libraryThread) {
        if (GetThreadId(m_libraryThread) == GetCurrentThreadId()) {
            LeaveCriticalSection(&m_libraryLock); return -1;
        }

        g_requestExit = true;
        WaitForSingleObject(m_libraryThread, INFINITE);
        CloseHandle(m_libraryThread);
        m_libraryThread = NULL;
        g_logProc = NULL;
        g_updateProc = NULL;
    }
    LeaveCriticalSection(&m_libraryLock);
    return 0;
}

BOOL WINAPI DllMain(
    _In_ HINSTANCE hinstDLL,
    _In_ DWORD     fdwReason,
    _In_ LPVOID    lpvReserved
)
{
    switch (fdwReason) {
    case DLL_PROCESS_ATTACH:
        InitializeCriticalSection(&m_libraryLock);
        InitializeCriticalSection(&m_configLock);
        break;

    case DLL_PROCESS_DETACH:
        Exit();
        break;
    }

    return TRUE;
}

namespace PlayspaceMover
{
    Options configuration() {
        EnterCriticalSection(&m_configLock);
        PlayspaceMover::Options options = g_options;
        LeaveCriticalSection(&m_configLock);
        return options;
    }

    void log(uint64_t level, const wchar_t* message) {
        if (g_logProc) (*g_logProc)(level, message);
    }

    TrackerState update(PlayState state) {
        if (g_updateProc) return (*g_updateProc)(state);
        else return TrackerState();
    }
}
