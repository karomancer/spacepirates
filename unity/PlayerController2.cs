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

    public GameObject compass;

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

    public float flashTime;
    Color originalColor;
    public SpriteRenderer renderer;

    public AudioSource audioSource;
    public AudioClip healClip;
    public AudioClip damageClip;
    public AudioClip lostDelivery;
    public AudioClip gotDelivery;
    public float volume = 0.5f;



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
        renderer = GetComponent<SpriteRenderer>();
        //print(renderer);
        originalColor = renderer.color;
        //print(originalColor);
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Lerp(10,0,playerSpeed);
        print("player speed");
        print(playerSpeed);
        Move();
        Vector3 r = new Vector3(0, 0, rotation) * Time.deltaTime;
        transform.Rotate(r);
    }

    void MoveLeft()
    {
        if (rotation < rotationLimit)
        
        {
            //print("left");
            rotation += rotationInc;
            compass.transform.Rotate(new Vector3(0,0,-rotationInc));
        }
    }
    void MoveRight()
    {
        if (rotation > -1*rotationLimit)
        {
        //print("right");
        rotation -= rotationInc;
        compass.transform.Rotate(new Vector3(0,0,rotationInc));
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
        audioSource.PlayOneShot(damageClip, volume);
        FlashRed();
        playerNewHealth = playerHealth - damageAmount;

        if (numDeliveries == 3 && playerHealth > 75 && playerNewHealth <= 75)
        {
            audioSource.PlayOneShot(lostDelivery, volume);
            Instantiate(delivery, transform.position, Quaternion.identity);
            numDeliveries--;
            delivery3.SetActive(false);
        }

        if (numDeliveries >= 2 && playerHealth > 50 && playerNewHealth <= 50)
        {
            audioSource.PlayOneShot(lostDelivery, volume);
            Instantiate(delivery, transform.position, Quaternion.identity);
            numDeliveries--;
            delivery2.SetActive(false);
        }

        if (numDeliveries >= 1 && playerHealth > 25 && playerNewHealth <= 25)
        {
            audioSource.PlayOneShot(lostDelivery, volume);
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
        //print(playerHealth);
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

        else if (collision.gameObject.tag == "EnemyFollower"|| collision.gameObject.tag == "Enemy_Shooter" || collision.gameObject.tag == "EnemyMover")
        {
            TakeDamage(1);
        }

        else if (collision.gameObject.tag == "Healer")
        {
            audioSource.PlayOneShot(healClip, volume);
            Heal(healAmount);
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Delivery")
        {
            audioSource.PlayOneShot(gotDelivery, volume);
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

    void FlashRed()
    {
        renderer.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        renderer.color = originalColor;
    }


}





