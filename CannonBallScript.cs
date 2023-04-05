using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour
{
    private GameObject cannon;
    public float speed = 0.001f;
    public float cannonRotation;

    // Start is called before the first frame update
    void Start()
    {
        cannon = GameObject.FindGameObjectWithTag("Cannon");

        // on instantiation, get current rotation of cannon (z axis)
        cannonRotation = cannon.transform.eulerAngles.z;

        // need to convert to radians to get angle in degrees 
        cannonRotation = (cannonRotation * Mathf.PI)/180;

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // bc of how unity deals with angles a "true" 90 degrees is really 0 degrees
        // not entirely sure why this works but it gives wanted behavior
        // there has to be an easier way to do this?

        transform.Translate(new Vector3(-Mathf.Sin(cannonRotation), Mathf.Cos(cannonRotation), 0) * speed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // destroy enemy upon collision.  destroy itself with enemy or obstacle collision
        print("in collider");
        if (collider.gameObject.tag == "Enemy")
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }

        else if (collider.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
