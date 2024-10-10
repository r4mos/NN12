#ifndef PCH_H
#define PCH_H

#include <windows.h>

#ifdef __cplusplus
extern "C" {
#endif

__declspec(dllexport) BOOL __cdecl CheckSerial(DWORD id, DWORD serial);

#ifdef __cplusplus
}
#endif

#endif
