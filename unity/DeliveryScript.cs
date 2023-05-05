using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryScript : MonoBehaviour
{
    public int speed = 10;
    public float enableTime = 2f;
    public Vector3 playerPosition;
    public Vector3 newPosition;
    private Vector3 spawn_transform;
    private float differenceFloat;
    private Vector3 differenceVector;
    public GameObject player;
    private PlayerController PlayerController;
    float timeTracker;
    // Start is called before the first frame update
    void Start()
    {
        timeTracker = Time.time;
        GetComponent<BoxCollider2D>().enabled = false;
        // PlayerController = GetComponent<PlayerController>();
        // spawn_transform = PlayerController.spawn_transform;
        // print(spawn_transform);
        // // print("spawn transform");
        // // print(spawn_transform);
        // player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i <= 20; i++)
        {
            //player.transform.position = new Vector3(Random.Range(0,10), Random.Range(0,10), 0);
            spawn_transform= new Vector3(Random.Range(player.transform.position.x-5,player.transform.position.x+5), Random.Range(player.transform.position.y-5,player.transform.position.y+5), 0);
            differenceVector = player.transform.position - spawn_transform;
            differenceFloat = differenceVector.x + differenceVector.y + differenceVector.z;
            if (Mathf.Abs(differenceFloat) > 3)
            {
                newPosition = spawn_transform;
                print(newPosition);
                break;
            }
        }

        playerPosition = player.transform.position;
        // newPosition = player.transform.position + new Vector3(Random.Range(5,10),Random.Range(5,10),0);
    }

    // Update is called once per frame
    void Update()
    {
         if (Time.time > enableTime + timeTracker)
         {
            GetComponent<BoxCollider2D>().enabled = true;
         }

         Vector3 position = this.transform.position;
         //print("my position is");
         //print(position);
         position.x = Mathf.Lerp(this.transform.position.x, spawn_transform.x, speed * Time.deltaTime);
         position.y = Mathf.Lerp(this.transform.position.y, spawn_transform.y, speed * Time.deltaTime);
         this.transform.position = position;
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
