using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryScript : MonoBehaviour
{
    public int speed = 10;
    public float enableTime = 1f;
    public Vector3 playerPosition;
    public Vector3 newPosition;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform.position;
        newPosition = player.transform.position + new Vector3(Random.Range(5,10),Random.Range(5,10),0);
    }

    // Update is called once per frame
    void Update()
    {
         if (Time.time > enableTime)
         {
            GetComponent<BoxCollider2D>().enabled = true;
         }

         Vector3 position = this.transform.position;
         position.x = Mathf.Lerp(this.transform.position.x, newPosition.x, speed * Time.deltaTime);
         position.y = Mathf.Lerp(this.transform.position.y, newPosition.y, speed * Time.deltaTime);
         this.transform.position = position;
    }
}
