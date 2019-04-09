

#ifndef _ABC_STD_TYPES
#define _ABC_STD_TYPES

#if defined(_ABC_X42)
	typedef unsigned int Uint_32;
	typedef unsigned short Uint_16;
	typedef unsigned char Uint_8;
	
	typedef int Int_32;
	typedef short Int_16;
	typedef char Int_8;

#elif defined (_ABC_A42)
	typedef unsigned long Uint_32;
	typedef unsigned int Uint_16;
	typedef unsigned char Uint_8;
	
	typedef long Int_32;
	typedef int Int_16;
	typedef char Int_8;
#else
	#error <abctypes.h> is not supported for this environment
#endif

#endif


// This Headerfile should not be used directly.
// Otherwise coe gets tied to one of the ABC Processors
// The code can´t compile unles you include this header.
// If _ABC_X42 or _ABC_A42 is used the integers will be the wrong size
// if the code is tested off-target
// Porting an application to another processor and using this header directly,
// will be much more difficult