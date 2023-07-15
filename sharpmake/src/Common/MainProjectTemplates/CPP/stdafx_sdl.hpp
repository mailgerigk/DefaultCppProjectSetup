#pragma once

#if __has_include(<SDL.h>)

#pragma warning(push)
// 'function' : unreferenced inline function has been removed
#pragma warning(disable : 4514)
// 'bytes' bytes padding added after construct 'member_name'
#pragma warning(disable : 4820)

#include <SDL.h>
#include <SDL_opengl.h>

#pragma warning(pop)

#endif