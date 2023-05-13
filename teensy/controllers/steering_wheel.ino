/* Steering Wheel */

void setupSteeringWheel() {
  // Ensure the steering wheel starts at 0
  // @TODO: Figure out how to reset at 0 for each new game
  // (assuming we don't reset the arduino code every game, but maybe Unity can send out
  // a serial command to reset the steering wheel value)
  steeringWheel.write(0);
}

void senseSteering() {
  int currentWheelLoc = steeringWheel.read();
  Joystick.button(8, 0);
  Joystick.button(7, 0);

  // Start game at neutral or if they get back to 0
  if (currentWheelLoc == 0) {
    previousDirection = NEUTRAL;
    return;
  }

  // If captain hasn't changed the wheel location,
  // continue to go in same direction as previously
  if (currentWheelLoc == previousWheelLoc) {
    //Serial.print("NEUTRAL: STILL ");
    switch (previousDirection) {
      case LEFT: break;
      case NEUTRAL: break;
      case RIGHT: break;
    }
    return;
  }

  currentWheelLoc > previousWheelLoc ? _wheelTurnLeft() : _wheelTurnRight();
  previousWheelLoc = currentWheelLoc;
}

void _wheelTurnLeft() {
  Joystick.button(7, 1);
  //Joystick.button(8, 0);
  //Serial.println("TURN LEFT");
  previousDirection = LEFT;
}

void _wheelTurnRight() {
  Joystick.button(8, 1);
  //Joystick.button(7, 0);
  //Serial.println("TURN RIGHT");
  previousDirection = RIGHT;
}
