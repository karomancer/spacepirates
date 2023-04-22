// right now this is handling multiple enemy classes, since there is relatively little code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyHealth = 100;
    public int enemyMaxHealth = 100;
    public float fireCooldown = 1f;
    public float directionChangeInterval = 4f;
    public float speed = 1f;
    private float timeStampFire;
    private float timeStampChangeDirection;
    private float randX;
    private float randY;
    private float moverType;

    public GameObject enemyProjectile;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // randomly rotate enemies on instantiation
        //transform.Rotate(0,0,Random.Range(0,360));
        // set timers for firing / changing movement direction
        timeStampFire = Time.time + fireCooldown;
        timeStampChangeDirection = Time.time + directionChangeInterval;
        // set initial x,y movement direction
        randX = Random.Range(-100f,100f)/75;
        randY = Random.Range(-100f,100f)/75;

        if (gameObject.tag == "EnemyFollower")
        {
            moverType = Random.Range(0f,50f)/10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //timeStamp = Time.time + fireCooldown;
        if (gameObject.tag == "Enemy_Shooter" && timeStampFire <= Time.time)
        {
            Fire();
            timeStampFire = Time.time + fireCooldown;
        }

        if (gameObject.tag == "EnemyFollower") {
            Follow();
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
        // the below 5 lines make the enemy rotate towards the player so it fires directly at the player
        // we can make this a separate class if we want?

        Vector2 directionToTarget = player.transform.position - transform.position;
        //float angle = Vector3.Angle(Vector3.right, directionToTarget);
        float angle = Vector3.Angle(Vector3.up, directionToTarget);
        //if(player.transform.position.y < transform.position.y) angle *= -1;
        if(player.transform.position.x > transform.position.x) angle *= -1;
        Quaternion bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Quaternion bulletRotation2 = Quaternion.AngleAxis(angle + 10, Vector3.forward);
        Quaternion bulletRotation3 = Quaternion.AngleAxis(angle - 10, Vector3.forward);

        Instantiate(enemyProjectile, transform.position, bulletRotation);
        Instantiate(enemyProjectile, transform.position, bulletRotation2);
        Instantiate(enemyProjectile, transform.position, bulletRotation3);

        //Instantiate(enemyProjectile, transform.position, Quaternion.identity);
    }

    void Follow()
    {
        Vector3 position = this.transform.position;

            if (moverType < 1)
            {
                position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, speed * Time.deltaTime);
                position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, speed * Time.deltaTime);
            }

            else if (moverType < 2)
            {
                position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x + 5, speed * Time.deltaTime);
                position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, speed * Time.deltaTime);
            }

            else if (moverType < 3)
            {
                position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x - 5, speed * Time.deltaTime);
                position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, speed * Time.deltaTime);
            }

            else if (moverType < 4)
            {
                position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, speed * Time.deltaTime);
                position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y + 5, speed * Time.deltaTime);
            }

            else
            {
                position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, speed * Time.deltaTime);
                position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y + 5, speed * Time.deltaTime);
            }
  
            this.transform.position = position;
    }
}
