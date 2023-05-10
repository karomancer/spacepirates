using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandArrowScript : MonoBehaviour
{
    public GameObject player;
    public GameObject island;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        island = GameObject.FindGameObjectWithTag("Island");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToTarget = player.transform.position - island.transform.position;
        float angle = Vector3.Angle(Vector3.up, directionToTarget);
        if(player.transform.position.x > island.transform.position.x) angle *= -1;
        Quaternion followerRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = followerRotation;
    }
}
