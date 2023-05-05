using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CannonLeft : MonoBehaviour
{
    Playercontrols controls;
    public GameObject cannonBall;
    public GameObject cannon;
    public GameObject player;
    private CannonBallLeftScript CannonBallLeftScript;

    public float rotationSpeed = 0.05f;

    float rotateLeft;
    float rotateRight;
    float cannonRotation;

    public AudioSource audioSource;
    public AudioClip fireClip;
    public float volume = 0.5f;

    void Awake()
    {
        // UNCOMMENT FOR PHYS CONTROLS
        controls = new Playercontrols();

        controls.LeftCannon.Steer.performed += ctx => rotateLeft = ctx.ReadValue<float>();
        controls.LeftCannon.Steer.canceled += ctx => rotateLeft = 0f;
        controls.LeftCannon.Shoot.performed += ctx => Fire();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //transform.Rotate(new Vector3(0,0,90));
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        //print(transform.eulerAngles.z);
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            Fire();
        }
    }

    void Rotate() 
    {
        // UNCOMMENT FOR PHYS CONTROLS
        // cannonRotation = map(rotateLeft,-1,1,0,180);
        // //transform.eulerAngles = new Vector3(0,0,cannonRotation + player.transform.eulerAngles.z + 90);
        // transform.eulerAngles = new Vector3(0,0,cannonRotation + player.transform.eulerAngles.z);  





        // Q = counterclockwise, E = clockwise
        // print(transform.eulerAngles.z);

        // if (Input.GetKey(KeyCode.Q) && (transform.eulerAngles.z < 180 || transform.eulerAngles.z > 355)) {
        //     transform.Rotate(new Vector3(0,0,rotationSpeed));
        // }

        // if (Input.GetKey(KeyCode.E) && transform.rotation.z > 0) {
        //     transform.Rotate(new Vector3(0,0,-rotationSpeed));
        // }

        if (Input.GetKey(KeyCode.Q) && (player.transform.eulerAngles.z - transform.eulerAngles.z) < 180) {
            transform.Rotate(new Vector3(0,0,rotationSpeed));
        }

        if (Input.GetKey(KeyCode.E) && (player.transform.eulerAngles.z - transform.rotation.z > 0)) {
            transform.Rotate(new Vector3(0,0,-rotationSpeed));
        }
    }
    
    void Fire()
    {
        // here we just instantiate cannonBall, CannonBallScript has other behaviors
        // mess with transform.position, see if can move origin point on x some fixed amt
        //transform.position.x - 5 etc.
        audioSource.PlayOneShot(fireClip, volume);
        
        Instantiate(cannonBall, transform.position, Quaternion.identity);

    }
    

    // void OnEnable()
    // {
    //     controls.LeftCannon.Enable();
    // }

    // void OnDisable()
    // {
    //     controls.LeftCannon.Disable();
    // }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }


}
