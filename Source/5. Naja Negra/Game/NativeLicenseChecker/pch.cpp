#include "pch.h"

DWORD GenerateSerial(DWORD seed, WORD base1, WORD base2, WORD base3, WORD base4)
{
    WORD seedHigh = seed >> 16;
    WORD seedLow = seed;
    WORD passHigh = 0x0000;
    WORD passLow = 0x0000;

    for (int i = 0; i < 10; i++)
    {
        passHigh = ~seedHigh;
        passHigh ^= seedLow;

        passLow = seedLow;
        passLow *= base1;
        passLow -= base2;
        passLow ^= seedHigh;

        seedHigh = base3;
        seedHigh ^= passHigh;
        seedLow = base4;
        seedLow ^= passLow;
    }

    DWORD pass;
    pass = passHigh;
    pass <<= 16;
    pass |= passLow;
    pass ^= seed;

    return pass;
}

BOOL CheckSerial(DWORD id, DWORD serial)
{
    return GenerateSerial(id, 0xDEAD, 0xBEEF, 0xBAAD, 0xF00D) == serial;
}