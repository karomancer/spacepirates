// KEEPING FOR POSTERITY, DO NOT USE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportController : MonoBehaviour
{
    private PlayerController PlayerController;

    public GameObject player;
    
    public float supportSpeed = 10f;
    public float supportRotationSpeed = 0.5f;
    public int healAmount = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.J)) {
            transform.Rotate(new Vector3(0,0,supportRotationSpeed));
        }

        if (Input.GetKey(KeyCode.L)) {
            transform.Rotate(new Vector3(0,0,-supportRotationSpeed));
        }

        if (Input.GetKey(KeyCode.I)) {
            transform.Translate(Vector3.up * supportSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.K)) {
            transform.Translate(Vector3.down * supportSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Healer")
        {
            player.GetComponent<PlayerController>().Heal(healAmount);
            Destroy(collision.gameObject);
        }
    }
}
