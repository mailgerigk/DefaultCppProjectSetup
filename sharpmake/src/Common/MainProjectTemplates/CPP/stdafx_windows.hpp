#pragma once

#if _WIN32

// enable crt leak detection
#define _CRTDBG_MAP_ALLOC
#include <crtdbg.h>
#include <stdlib.h>

#if _DEBUG
inline static int setReportModeInitializer = ([]() { _CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF); return 0; })();
#endif

// windows header
#define NOMINMAX
#define WIN32_LEAN_AND_MEAN

#if __has_include(<raylib.h>)
#define NOGDI
#define NOUSER
#endif

#pragma warning(push)
// 'function': pointer or reference to potentially throwing function passed to extern C function under -EHc. Undefined behavior may occur if this function throws an exception.
#pragma warning(disable : 5039)

#include <Windows.h>

#pragma warning(pop)

#undef near
#undef far

#if __has_include(<raylib.h>)
#undef NOUSER
#undef NOGDI
#endif

#undef NOMINMAX
#undef WIN32_LEAN_AND_MEAN

#endif