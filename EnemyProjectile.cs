// basically a copy of cannonballscript

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private EnemyScript EnemyScript;
    private PlayerController PlayerController;

    public GameObject enemy;
    
    public float speed = 0.001f;
    public float enemyRotation;
    public int damage = 30;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy_Shooter");

        enemyRotation = enemy.transform.eulerAngles.z;

        // need to convert to radians to get angle in degrees 
        enemyRotation = (enemyRotation * Mathf.PI)/180;

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-Mathf.Sin(enemyRotation), Mathf.Cos(enemyRotation), 0) * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        // damage player upon collision.  destroy itself with any collision
        //print("in collider");
        if (collider.gameObject.tag == "Player")
        {
            // damage player
            collider.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
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

    }
}
