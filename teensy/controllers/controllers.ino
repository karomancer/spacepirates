#include <Encoder.h>

/*******************************
 * STEERING WHEEL DECLARATIONS *
 *******************************/
enum Direction { LEFT,
                 NEUTRAL,
                 RIGHT };
enum Direction previousDirection = NEUTRAL;
int previousWheelLoc = 0;

Encoder steeringWheel(11, 12);

/*******************************
 ***** CANNON DECLARATIONS *****
 *******************************/
 const int LeftCannonDirection = 15;
 const int RightCannonDirection = 16;
 
 const int LeftCannonFire = 17;
 const int RightCannonFire = 18;

/**************************************
 **** JOYSTICK BUTTON DECLARATIONS ****
 *************************************/
 