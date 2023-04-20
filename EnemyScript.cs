// right now this is handling multiple enemy classes, since there is relatively little code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyHealth = 100;
    public int enemyMaxHealth = 100;
    public float fireCooldown = 1f;
    public float speed = 1f;
    private float timeStamp;
    private float rand_x;
    private float rand_y;

    public GameObject enemyProjectile;


    // Start is called before the first frame update
    void Start()
    {
        // timer for shooter enemies
        timeStamp = Time.time + fireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        //timeStamp = Time.time + fireCooldown;
        if (gameObject.tag == "Enemy_Shooter" && timeStamp <= Time.time)
        {
            Fire();
            timeStamp = Time.time + fireCooldown;
        }

        // NOT WORKING AS INTENDED - will change so that movement is constant but random direction is picked
        // on some interval
        if (gameObject.tag == "EnemyMover" && timeStamp <= Time.time) {
            rand_x = Random.Range(-100f,100f)/75;
            rand_y = Random.Range(-100f,100f)/75;
            print(rand_x);
            print(rand_y);
            //transform.Translate(new Vector3(Random.Range(-1,1), Random.Range(-1,1), 0) * speed * Time.deltaTime);
            transform.Translate(new Vector3(rand_x, rand_y, 0) * speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damageAmount)
    // subtract damage done from health, and destroy object if it has 0 health
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        print(enemyHealth);
    }

    void Fire()
    // fire weapon
    {
        Instantiate(enemyProjectile, transform.position, Quaternion.identity);
    }
}
