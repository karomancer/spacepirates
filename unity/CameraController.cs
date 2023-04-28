using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // match x,y of camera to x,y of player so player is always in the center of the frame
        // -10 z value is the default
        transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y, -10);
        // match player rotation
        transform.rotation = player.transform.rotation;

    }
}
