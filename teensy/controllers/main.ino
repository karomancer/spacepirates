void setup() {
  // Setup Cannons
  pinMode(LeftCannonDirection, INPUT);         //Left Cannon turn
  pinMode(RightCannonDirection, INPUT);         //Right cannon turn
  pinMode(LeftCannonFire, INPUT_PULLUP);  //Fire button
  pinMode(RightCannonFire, INPUT);         //FIre button right

  //Speed
  pinMode(20, INPUT);
}

void loop() {
  // Steering wheel
  senseSteering();

  // Cannons
  Joystick.Zrotate(analogRead(LeftCannonDirection));
  Joystick.Zrotate(analogRead(RightCannonDirection));

  if (!digitalRead(LeftCannonFire)) {
    Joystick.button(4, 1);
    delay(50);
  } else {
    Joystick.button(4, 0);
  }
  if (!digitalRead(RightCannonFire)) {
    Joystick.button(5, 1);
    delay(50);
  } else {
    Joystick.button(5, 0);
  }
}