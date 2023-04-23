using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController2 : MonoBehaviour
{
   
    
    public GameObject cannonBall;

    public float playerSpeed = 10f;
    public float playerRotationSpeed = 0.5f;
    public float playerAngle = 0;
    public float angleIncrement = 0.1f;
    public bool reachedIsland = false;
    public int playerHealth = 100;
    public int playerMaxHealth = 100;
    public int healAmount = 20;



    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        print(playerAngle);
    }

    void Move()
    {
        //transform.Rotate(new Vector3(0,0,playerAngle));
        // can/should i make more boat-like?
        if (Input.GetAxisRaw("Horizontal") < 0) 
        {
         playerAngle += angleIncrement;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
         playerAngle -= angleIncrement;
        }
        
        if (Input.GetAxisRaw("Vertical") < 0) 
        {
         transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
         transform.Rotate(new Vector3(0,0,playerAngle));
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
         transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
         transform.Rotate(new Vector3(0,0,playerAngle));
        }
    }

    public void TakeDamage(int damageAmount)
    // take damage
    {
        playerHealth -= damageAmount;
        if (playerHealth < 0)
        {
            playerHealth = 0;
        }
        //print(playerHealth);
    }

    public void Heal(int healAmount)
    // heal health, make sure to not go above max
    {
        playerHealth += healAmount;
        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
        //print(playerHealth);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Island")
        {
            reachedIsland = true;
        }

        else if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Enemy_Shooter" || collision.gameObject.tag == "EnemyMover")
        {
            TakeDamage(50);
        }

        else if (collision.gameObject.tag == "Healer")
        {
            Heal(healAmount);
            Destroy(collision.gameObject);
        }

        // else if(collision.gameObject.tag == "Healer")
        // {
        //     Heal(10);
        //     Destroy(collision.gameObject);
        // }

        // TO IMPLEMENT - how to ignore collision with myself?
        // this is needed to 1. avoid recoil, 2. avoid collision physics if i am hit with my own cannonball
        // below is NOT WORKING 4/7 1:56pm

        // else if (collision.gameObject.tag == "CannonBall")
        // {
        //     print("hittin cball");
        //     Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        // }
    }




}





