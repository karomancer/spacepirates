using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLeft : MonoBehaviour
{
    public GameObject cannonBall;
    public GameObject cannon;
    private CannonBallLeftScript CannonBallLeftScript;

    public float rotationSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(new Vector3(0,0,90));
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
        print(transform.eulerAngles.z);
        if (Input.GetKey(KeyCode.Q) && (transform.eulerAngles.z < 180 || transform.eulerAngles.z > 355)) {
            transform.Rotate(new Vector3(0,0,rotationSpeed));
        }

        if (Input.GetKey(KeyCode.E) && transform.rotation.z > 0) {
            transform.Rotate(new Vector3(0,0,-rotationSpeed));
        }
    }
    
    void Fire()
    {
        // here we just instantiate cannonBall, CannonBallScript has other behaviors
        // mess with transform.position, see if can move origin point on x some fixed amt
        //transform.position.x - 5 etc.

        Instantiate(cannonBall, transform.position, Quaternion.identity);
        //cannonBall.transform.SetParent(gameObject.transform);
        // if (gameObject.tag == "LeftCannon") {
        //     cannon.GetComponent<CannonBallScript>().setCannon(GameObject.FindGameObjectWithTag("LeftCannon"));
        // }

        // if (gameObject.tag == "RightCannon") {
        //     cannon.GetComponent<CannonBallScript>().setCannon(GameObject.FindGameObjectWithTag("RightCannon"));
        // }
        //cannon.GetComponent<CannonBallScript>().cannon = this.gameObject;
    }

    // ignore this, trying to use this to solve cannonball spawn problem
    
    public GameObject returnCannon()
    {   print(gameObject);
        return gameObject;
    }
}
