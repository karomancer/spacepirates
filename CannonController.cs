using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonBall;

    public float rotationSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
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
        // Q = counterclockwise, E = clockwise

        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(new Vector3(0,0,rotationSpeed));
        }

        if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(new Vector3(0,0,-rotationSpeed));
        }
    }
    
    void Fire()
    {
        // here we just instantiate cannonBall, CannonBallScript has other behaviors
        // mess with transform.position, see if can move origin point on x some fixed amt
        //transform.position.x - 5 etc.

        Instantiate(cannonBall, transform.position, Quaternion.identity);
        
    }
}
