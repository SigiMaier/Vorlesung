

// Instead of using special headerfiles directly
// a more standardized path should be used by using stdint.h
// If target compiler does not provide stdint.h, this kind of headerfile can be used

#ifndef _STDINT_H_
#define _STDINT_H_

#include <abctypes.h>

typedef Uint_32 uint32_t;
typedef Uint_16 uint16_t;
typedef Uint_8 uint8_t;

typedef Int_32 int32_t;
typedef Int_16 int16_t;
typedef Int_8 int8_t;

#endif

// By using stdint.h in embedded software and hardware helps to keep the code clean and portable
// All software should be processor independent, but not all of the firmware can be