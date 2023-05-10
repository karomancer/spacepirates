using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCannonScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToTarget = player.transform.position - transform.position;
        float angle = Vector3.Angle(Vector3.up, directionToTarget);
        if(player.transform.position.x > transform.position.x) angle *= -1;
        Quaternion myRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = myRotation;
    }
}
