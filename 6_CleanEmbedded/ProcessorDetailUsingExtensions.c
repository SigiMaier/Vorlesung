

// this code uses special extensions to C that gives access
// to the peripherals in the micro-controller

void say_hi()
{
	IE = 0b11000000;
	SBUF0 = (0x68);
	while(TI_0 == 0);
	TI_0 = 0;
	SBUF0 = (0x69);
	while(TI_0 == 0);
	TI_0 = 0;
	SBUF0 = (0x0a);
	while(TI_0 == 0);
	TI_0 = 0;
	SBUF0 = (0x0d);
	while(TI_0 == 0);
	TI_0 = 0;
	IE = 0b11010000;
}

// This function contains many problems.
// This code uses lots of custom C extensions.

// IE: Interrupt enable bits
// SBUF0: Serial output buffer
// TI_0: Serial transmit buffer empty interrupt. Reading a 1 indicates the buffer is empty

// The uppercase variables access micro-controller built-in peripherals that have to be used
// if the interrupts and output characters want to be controlled
// this is convenient but not C

// Clean embedded architecture uses these device access registers directly in very few places
// and confine them totally to the firmware.
// Anything that knows about these registers becomes firmware and is bound to the processor