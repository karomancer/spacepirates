using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
   
    
    public GameObject cannonBall;
    public Rigidbody2D playerRB;

    public float playerSpeed = 1f;
    public float playerRotationSpeed = 0.5f;
    public float playerAngle;
    public bool reachedIsland = false;
    public int playerHealth = 100;
    public int playerMaxHealth = 100;
    public int healAmount = 20;

    public Vector3 directionVector;



    void Awake()
    {
        //playerRB = gameObject.AddComponent<Rigidbody2D>();
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        playerSpeed = 1f;
        Move();
        //MoveRB();
        //print(rotateLeft);
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
         playerSpeed = 10f;
         directionVector = Vector3.up * playerSpeed * Time.deltaTime;
         transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
        }
    }

    void MoveRB() 
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            playerRB.AddForce(transform.up * playerSpeed);
        }

        if (Input.GetAxisRaw("Horizontal") < 0) 
        {
         transform.Rotate(new Vector3(0,0,playerRotationSpeed));
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
         transform.Rotate(new Vector3(0,0,-playerRotationSpeed));
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





