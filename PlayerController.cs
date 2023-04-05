using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cannonBall;

    public float playerSpeed = 10f;
    public float playerRotationSpeed = 0.5f;
    public float playerAngle;
    public bool reachedIsland = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {

        // can/should i make more boat-like?
        if (Input.GetAxisRaw("Horizontal") < 0) 
        {
         transform.Rotate(new Vector3(0,0,playerRotationSpeed));
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
         transform.Rotate(new Vector3(0,0,-playerRotationSpeed));
        }
        
        if (Input.GetAxisRaw("Vertical") < 0) 
        {
         transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
         transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Island")
        {
            reachedIsland = true;
        }

        else if (collision.gameObject.tag == "Enemy")
        {
            print("enemy");
        }

        // to implement - how to ignore collision with myself?
        // this is needed to 1. avoid recoil, 2. avoid collision physics if i am hit with my own cannon

        //else if (collision.gameObject.tag == "CannonBall")
       // {
            //Physics.IgnoreCollision(collision.gameObject.collider, gameObject.Collider2D);
       // }
    }



}





