using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour
{
    private GameObject cannon;
    private EnemyScript EnemyScript;


    public float speed = 0.001f;
    public float cannonRotation;
    public int damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        cannon = GameObject.FindGameObjectWithTag("Cannon");
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

        transform.Translate(new Vector3(-Mathf.Sin(cannonRotation), Mathf.Cos(cannonRotation), 0) * speed * Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // damage enemy upon collision.  destroy itself with any collision
        print("in collider");
        if (collider.gameObject.tag == "Enemy")
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
            print("hitting player");
            //Physics2D.IgnoreCollision(collider.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
