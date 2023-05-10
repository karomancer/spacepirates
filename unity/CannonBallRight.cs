// spawn as child, inherit oreintation

// READ ME FIRST
// trying to have this script handle cannonballs both L and R cannons
// having trouble getting which cannon spawned a given cannonball
// so i can properly assign rotation / direction
// need to ask mark

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallRight : MonoBehaviour
{
    public GameObject player;
    public GameObject cannon;
    private EnemyScript EnemyScript;
    private CannonLeft CannonLeft;


    public float speed = 100.001f;
    public float cannonRotation;
    public int damage = 50;
    private float playerSpeed;
    private float speedScalar = 5f;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        cannon = GameObject.FindGameObjectWithTag("RightCannon");
        //playerSpeed = player.GetComponent<PlayerController>().playerSpeed;
        playerSpeed = player.GetComponent<PlayerController2>().playerSpeed;

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

        // if (playerSpeed < 1.1f)
        // {
        //     transform.Translate((new Vector3(-Mathf.Sin(cannonRotation), Mathf.Cos(cannonRotation), 0) * speed * Time.deltaTime) * (speedScalar * playerSpeed/2));
        // }
        
        // else
        // {
        //      transform.Translate((new Vector3(-Mathf.Sin(cannonRotation), Mathf.Cos(cannonRotation), 0) * speed * Time.deltaTime) * playerSpeed/2);
        // }

        transform.Translate((new Vector3(-Mathf.Sin(cannonRotation), Mathf.Cos(cannonRotation), 0) * speed * Time.deltaTime) * 4);


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // damage enemy upon collision.  destroy itself with any collision
        if (collider.gameObject.tag == "Enemy" || collider.gameObject.tag == "Enemy_Shooter" || collider.gameObject.tag == "EnemyMover" || collider.gameObject.tag == "EnemyFollower")
        {
            //print("hitting collider");
            // damage enemy
            //print("right cball hitting");
            collider.gameObject.GetComponent<EnemyScriptGH>().TakeDamage(damage);
            Destroy(gameObject);
        }

        // else if (collider.gameObject.tag == "EnemyFollower")
        // {
        //     // damage enemy
        //     //print("hitting collider");
        //     collider.gameObject.GetComponent<EnemyScriptGH>().TakeDamage(damage);
        //     Destroy(gameObject);
        //}

        else if (collider.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collider.gameObject);
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
