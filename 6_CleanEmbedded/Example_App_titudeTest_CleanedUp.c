

// Functions that have domain logic
float calc_RPM(void) { ... }
void Do_Average(void) { ... }
void Get_Next_Measurement(void) { ... }
void Zero_Sensor_1(void) { ... }
void Zero_Sensor_2(void) { ... }

// Functions that set up the hardware platform
ISR(TIMER1_vect) { ... }
ISR(INT2_vect) { ...}
void uC_Sleep(void) { ... }

// Functions that react to the on off button press
void btn_Handler(void) { ... }
void Dev_Control(char Activation) { ... }

// A Function that can get A/D input readings from the hardware
static char Read_RawData(void) { ... }

// Functions that store values to the persistent storage
char Load_FLASH_Setup(void) { ... }
void Save_FASH_Setup(void) { ... }
void Store_DataSet(void) { ... }
float bytes2float(char bytes[4]) { ... }
void Recall_DataSet(void) { ... }

// Function that does not do what its name implies
void Sensor_init(void) { ... }


// The code above knows it is in a special microprocessor architecture, using
// "extended" C constructs that tie the code to a particular tool chain and microprocessor
// This application works: The App-titude test passed. But the application can´t be said to have a clean
// embedded architecture