using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerProjectileNew: MonoBehaviour
{
    private EnemyScript EnemyScript;
    private PlayerController PlayerController;

    public GameObject enemy;
    public GameObject player;
    
    public float speed = 0.001f;
    public float enemyRotation;
    private int damage = 1;
    //public transform enemy;
    
    private Vector3 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //enemy = GameObject.FindGameObjectWithTag("Enemy_Shooter");
        enemy = this.transform.parent.gameObject;
        //print(enemy);

        enemyRotation = enemy.transform.eulerAngles.z;
        //playerDirection = player.GetComponent<PlayerController>().directionVector;
        playerDirection = player.GetComponent<PlayerController2>().directionVector;

        // need to convert to radians to get angle in degrees 
        enemyRotation = (enemyRotation * Mathf.PI)/180;

        Destroy(gameObject, 7);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.up * speed * Time.deltaTime);
        
        transform.Translate((new Vector3(-Mathf.Sin(enemyRotation), Mathf.Cos(enemyRotation), 0) + playerDirection) * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        // damage player upon collision.  destroy itself with any collision
        //print("in collider");
        if (collider.gameObject.tag == "Player")
        {
            // damage player
            //print("damaging");
            //collider.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            collider.gameObject.GetComponent<PlayerController2>().TakeDamage(damage);
            //Destroy(collider.gameObject);
            Destroy(gameObject);
        }

        else if (collider.gameObject.tag == "Obstacle" || collider.gameObject.tag == "Border" || collider.gameObject.tag == "EnemyShooterParent")
        {
            Destroy(gameObject);
        }

        else if (collider.gameObject.tag == "Island")
        {
            Destroy(gameObject);
        }

    }
}