using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


public class PlayerController2 : MonoBehaviour
{
    Playercontrols controls;
    
    public GameObject delivery1;
    public GameObject delivery2;
    public GameObject delivery3;
    
    public GameObject cannonBall;
    public GameObject delivery;
    public Rigidbody2D playerRB;

    public float playerSpeed = 0f;
    private float speed = 0f;
    public float speedLimit = 10f;
    public float speedInc = .1f;
    public float playerRotationSpeed = 0.5f;
    public float playerAngle;
    public bool reachedIsland = false;
    public int playerHealth = 100;
    public int playerNewHealth;
    public int playerMaxHealth = 100;
    public int healAmount = 20;
    public int numDeliveries = 3;
    private float rotation = 0f;
    public float rotationInc = .1f;
    public float rotationLimit = 60f;

    public Vector3 directionVector;

    public HealthBarScript healthBar;



    void Awake()
    {
        // UNCOMMENT FOR PHYS CONTROLS
        controls = new Playercontrols();

        controls.Ship.SteeringLeft.performed += ctx =>  MoveLeft();
        controls.Ship.SteeringRight.performed += ctx =>  MoveRight();

        controls.Ship.Speed.performed += ctx => playerSpeed = ctx.ReadValue<float>();
        controls.Ship.Speed.canceled += ctx => playerSpeed = 0f;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(playerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //playerSpeed = 1f;
        speed = map(playerSpeed, -1,1,0,8);
        Move();
        //transform.Rotate(new Vector3(0,0,rotation));
        Vector3 r = new Vector3(0, 0, rotation) * Time.deltaTime;
        transform.Rotate(r);
        //print(rotation);
        print(playerSpeed);
        // Vector3 m = Vector3.up * (playerSpeed/2) * Time.deltaTime;
        // transform.Translate(m);
        
        // MoveLeft();
        // MoveRight();
        //MoveRB();
        //print(rotateLeft);
    }

    void MoveLeft()
    {
        if (rotation < rotationLimit)
        
        {
            print("left");
            rotation += rotationInc;
        }
    }
    void MoveRight()
    {
        if (rotation > -1*rotationLimit)
        {
        print("right");
        rotation -= rotationInc;
        }
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
        
        // if (Input.GetAxisRaw("Vertical") < 0) 
        // {
        //  //playerSpeed = 10f;
        //  directionVector = Vector3.down * speed * Time.deltaTime;
        //  transform.Translate(Vector3.down * speed * Time.deltaTime);
        // }

        // if (Input.GetAxisRaw("Vertical") > 0)
        // {
         //playerSpeed = 10f;
         directionVector = Vector3.up * speed * Time.deltaTime;
         transform.Translate(Vector3.up * speed * Time.deltaTime);
        // }
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
        playerNewHealth = playerHealth - damageAmount;

        if (numDeliveries == 3 && playerHealth > 75 && playerNewHealth <= 75)
        {
            Instantiate(delivery, transform.position, Quaternion.identity);
            numDeliveries--;
            delivery3.SetActive(false);
        }

        if (numDeliveries >= 2 && playerHealth > 50 && playerNewHealth <= 50)
        {
            Instantiate(delivery, transform.position, Quaternion.identity);
            numDeliveries--;
            delivery2.SetActive(false);
        }

        if (numDeliveries >= 1 && playerHealth > 25 && playerNewHealth <= 25)
        {
            Instantiate(delivery, transform.position, Quaternion.identity);
            numDeliveries--;
            delivery1.SetActive(false);
        }


        if (playerHealth < 0)
        {
            playerHealth = 0;
            Destroy(gameObject);
        }

        playerHealth = playerNewHealth;
        healthBar.SetHealth(playerHealth);
        print(playerHealth);
    }


    public void Heal(int healAmount)
    {
        playerHealth = playerHealth + healAmount;

        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }

        healthBar.SetHealth(playerHealth);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Island")
        {
            reachedIsland = true;
        }

        else if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag == "Enemy_Shooter" || collision.gameObject.tag == "EnemyMover")
        {
            TakeDamage(1);
        }

        else if (collision.gameObject.tag == "Healer")
        {
            Heal(healAmount);
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Delivery")
        {
            numDeliveries++;
            if (numDeliveries == 3)
            {
                delivery3.SetActive(true);
            }

            else if (numDeliveries == 2)
            {
                delivery2.SetActive(true);
            }

            else if (numDeliveries == 1)
            {
                delivery1.SetActive(true);
            }



            Destroy(collision.gameObject);
        }

    }

    void OnEnable(){
        controls.Ship.Enable();
    }

    void OnDisable(){
        controls.Ship.Disable();
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }


}




