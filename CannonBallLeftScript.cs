// spawn as child, inherit oreintation

// READ ME FIRST
// trying to have this script handle cannonballs both L and R cannons
// having trouble getting which cannon spawned a given cannonball
// so i can properly assign rotation / direction
// need to ask mark

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallLeftScript : MonoBehaviour
{
    //private GameObject cannon;
    //public GameObject foo;
    public GameObject cannon;
    public GameObject player;
    private EnemyScript EnemyScript;
    private CannonLeft CannonLeft;


    public float speed = 0.001f;
    public float cannonRotation;
    public float speedScalar = 5f;
    public int damage = 50;
    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //print(transform.parent);
        //cannon = foo.GetComponent<CannonController>().returnCannon();
        //setCannon();
        player = GameObject.FindGameObjectWithTag("Player");
        cannon = GameObject.FindGameObjectWithTag("LeftCannon");

        playerSpeed = player.GetComponent<PlayerController>().playerSpeed;
        //public cannon = GameObject;
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());     

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

        if (playerSpeed < 1.1f)
        {
            transform.Translate((new Vector3(-Mathf.Sin(cannonRotation), Mathf.Cos(cannonRotation), 0) * speed * Time.deltaTime) * (speedScalar * playerSpeed/2));
        }
        
        else
        {
             transform.Translate((new Vector3(-Mathf.Sin(cannonRotation), Mathf.Cos(cannonRotation), 0) * speed * Time.deltaTime) * playerSpeed/2);
        }
       


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // damage enemy upon collision.  destroy itself with any collision
        //print("in collider");
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Enemy_Shooter" || collider.gameObject.tag == "EnemyMover" || collider.gameObject.tag == "EnemyFollower")
        {
            // damage enemy
            collider.gameObject.GetComponent<EnemyScript>().TakeDamage(damage);
            //Destroy(collider.gameObject);
            Destroy(gameObject);
        }

        else if (collider.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }

        else if (collider.gameObject.tag == "Island")
        {
            Destroy(gameObject);
        }

        else if (collider.gameObject.tag == "Player")
        {
            //print("hitting player");
            //Physics2D.IgnoreCollision(collider.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }


}
