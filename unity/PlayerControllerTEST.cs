using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControllerTEST : MonoBehaviour
{
    Playercontrols controls;
    float rotation = 0f;
    float r;

    void Awake()
    {
        controls = new Playercontrols();
        controls.Ship.SteeringLeft.performed += ctx => MoveLeft();
        controls.Ship.SteeringRight.performed += ctx => MoveRight();
    }

    void Start()
    {
        // controls.Ship.SteeringLeft.performed += ctx => MoveLeft();
        // controls.Ship.SteeringRight.performed += ctx => MoveRight();
    }

    void MoveLeft()
    {
        print("left");
        rotation += 5;
    }
    void MoveRight()
    {
        print("right");
        rotation -= 5;
    }

    void Update()
    {
        Vector3 r = new Vector3(0, 0, rotation) * Time.deltaTime;
        transform.Rotate(r);
    }

    void OnEnable(){
        controls.Ship.Enable();
    }

    void OnDisable(){
        controls.Ship.Disable();
    }
}
