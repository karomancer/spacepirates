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
 const int LeftCannonDirection = 14; //15
 const int RightCannonDirection = 15; //16
 
 const int LeftCannonFire = 9; //9
 const int RightCannonFire = 10; //10

/**************************************
 **** JOYSTICK BUTTON DECLARATIONS ****
 *************************************/
 