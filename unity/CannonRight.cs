using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CannonRight: MonoBehaviour
{
    Playercontrols controls;
    public GameObject cannonBall;
    public GameObject cannon;
    public GameObject player;



    private CannonBallRight CannonBallRight;

    public float rotationSpeed = 0.05f;
    float rotation;
    float cannonRotation;
    // Start is called before the first frame update

    void Awake()
    {
        // UNCOMMENT FOR PHYS CONTROLS
        controls = new Playercontrols();

        controls.RightCannon.Steer.performed += ctx => rotation = ctx.ReadValue<float>();
        controls.RightCannon.Steer.canceled += ctx => rotation = 0f;
        controls.RightCannon.Shoot.performed += ctx => Fire();
    }


    void Start()
    {
        transform.Rotate(new Vector3(0,0,-90));
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            Fire();
        }
    }

    void Rotate() 
    {
        // UNCOMMENT FOR PHYS CONTROLS
        cannonRotation = map(rotation,-1,1,0,-180);
        //transform.eulerAngles = new Vector3(0,0,cannonRotation + player.transform.eulerAngles.z - 90);
        transform.eulerAngles = new Vector3(0,0,cannonRotation + player.transform.eulerAngles.z);
        
        
        // I = counterclockwise, P = clockwise

        // if (Input.GetKey(KeyCode.I) && transform.eulerAngles.z > 170) {
        //     transform.Rotate(new Vector3(0,0,rotationSpeed));
        // }

        // if (Input.GetKey(KeyCode.P) && (transform.eulerAngles.z > 180 || transform.eulerAngles.z < Mathf.Abs(10))) {
        //     transform.Rotate(new Vector3(0,0,-rotationSpeed));
        // }
    }
    
    void Fire()
    {
        // here we just instantiate cannonBall, CannonBallScript has other behaviors
        // mess with transform.position, see if can move origin point on x some fixed amt
        //transform.position.x - 5 etc.

        Instantiate(cannonBall, transform.position, Quaternion.identity);

    }

    // ignore this, trying to use this to solve cannonball spawn problem
    

    void OnEnable()
    {
        controls.RightCannon.Enable();
    }

    void OnDisable()
    {
        controls.RightCannon.Disable();
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }
}
