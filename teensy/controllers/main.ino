void setup() {
  // Setup Cannons
  pinMode(LeftCannonDirection, INPUT);         //Left Cannon turn
  pinMode(RightCannonDirection, INPUT);         //Right cannon turn
  pinMode(LeftCannonFire, INPUT_PULLUP);  //Fire button
  pinMode(RightCannonFire, INPUT_PULLUP);         //FIre button right
  pinMode(23, INPUT_PULLUP); //22

  //Speed
  pinMode(20, INPUT);
}

void loop() {
  // Steering wheel
  senseSteering();

  // Cannons
  Joystick.Z(analogRead(LeftCannonDirection));
  Joystick.Zrotate(analogRead(RightCannonDirection));

  if (!digitalRead(LeftCannonFire)) {
    Serial.println("l cannon fire");
    Joystick.button(4, 1);

    delay(50);
  } else {
    Joystick.button(4, 0);
  }
  if (!digitalRead(RightCannonFire)) {
    Serial.println("r cannon fire");
    Joystick.button(5, 1);
    delay(50);
  } else {
    Joystick.button(5, 0);
  }

  //Speed
  //float speed = map(analogRead(20),0,1023,0,512);
  Joystick.Y(analogRead(20));

  if (!digitalRead(23)) {
    Joystick.button(1, 1);
    delay(50);
  } else {
    Joystick.button(1, 0);
  }
  //Serial.println(analogRead(RightCannonDirection));
}