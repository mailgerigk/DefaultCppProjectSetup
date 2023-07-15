#pragma once

#include "stdafx_windows.hpp"

#pragma warning(push)
// 'this' : used in base member initializer list
#pragma warning(disable : 4355)
// 'function' : unreferenced inline function has been removed
#pragma warning(disable : 4514)
// 'derived class' : copy constructor was implicitly defined as deleted because a base class copy constructor is inaccessible or deleted
#pragma warning(disable : 4625)
// 'derived class' : assignment operator was implicitly defined as deleted because a base class assignment operator is inaccessible or deleted
#pragma warning(disable : 4626)
// 'bytes' bytes padding added after construct 'member_name'
#pragma warning(disable : 4820)
// 'type': move constructor was implicitly defined as deleted
#pragma warning(disable : 5026)
// 'type': move assignment operator was implicitly defined as deleted
#pragma warning(disable : 5027)
// 'type-name': class has virtual functions, but its trivial destructor is not virtual; instances of objects derived from this class may not be destructed correctly
#pragma warning(disable : 5204)
// 'name': a non-static data member with a volatile qualified type no longer implies that compiler generated copy/move constructors and copy/move assignment operators are not
// trivial
#pragma warning(disable : 5220)
// implicit fall-through occurs here; are you missing a break statement? Use [[fallthrough]] when a break statement is intentionally omitted between cases
#pragma warning(disable : 5262)
// 'variable-name': 'const' variable is not used
#pragma warning(disable : 5264)

// Concepts library
#include <concepts>

// Coroutines library
#include <coroutine>

// Utilities library
#include <any>
#include <bitset>
#include <chrono>
#include <compare>
#include <csetjmp>
#include <csignal>
#include <cstdarg>
#include <cstddef>
#include <cstdlib>
#include <ctime>
// #include <expected>		not yet
#include <functional>
#include <initializer_list>
#include <optional>
#include <source_location>
#include <tuple>
#include <type_traits>
#include <typeindex>
#include <typeinfo>
#include <utility>
#include <variant>
#include <version>

// Dynamic memory management
#include <memory>
#include <memory_resource>
#include <new>
#include <scoped_allocator>

// Numeric limits
#include <cfloat>
#include <climits>
#include <cstdint>
#include <limits>

// Error handling
#include <cassert>
#include <cerrno>
#include <exception>
#include <stdexcept>
#include <system_error>
// #include <stacktrace>	not yet :(

// Strings library
#include <cctype>
#include <charconv>
#include <cstring>
#include <cuchar>
#include <cwchar>
#include <cwctype>
#include <format>
#include <string>
#include <string_view>

// Containers library
#include <array>
#include <deque>
#include <forward_list>
#include <list>
#include <map>
#include <queue>
#include <set>
#include <span>
#include <stack>
#include <unordered_map>
#include <unordered_set>
#include <vector>

// Iterators library
#include <iterator>

// Ranges library
#include <ranges>

// Algorithms library
#include <algorithm>
#include <execution>

// Numerics library
#include <bit>
#include <cfenv>
#include <cmath>
#include <complex>
#include <numbers>
#include <numeric>
#include <random>
#include <ratio>
#include <valarray>

// Localization library
#include <clocale>
#include <codecvt>
#include <locale>

// Input/output library
#include <cstdio>
#include <fstream>
#include <iomanip>
#include <ios>
#include <iosfwd>
#include <iostream>
#include <istream>
#include <ostream>
#include <spanstream>
#include <sstream>
#include <streambuf>
#include <syncstream>

// Filesystem library
#include <filesystem>

// Regular Expressions library
#include <regex>

// Atomic Operations library
#include <atomic>

// Thread support library
#include <barrier>
#include <condition_variable>
#include <future>
#include <latch>
#include <mutex>
#include <semaphore>
#include <shared_mutex>
#include <stop_token>
#include <thread>

#pragma warning(pop)

#include "stdafx_raylib.hpp"
#include "stdafx_sdl.hpp"
