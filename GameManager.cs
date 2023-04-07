using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerScriptHolder;
    public GameObject player;
    public GameObject island;
    public GameObject support;
    public GameObject enemy;
    public GameObject obstacle;
    public GameObject[] cannonBalls;
    public GameObject[] enemies;
    public GameObject[] obstacles;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = playerScriptHolder.GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player");
        island = GameObject.FindGameObjectWithTag("Island");
        support = GameObject.FindGameObjectWithTag("SupportBoat");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.reachedIsland == true)
        {
            // if boat hits island, generate new level
            GenerateNewLevel();
            playerController.reachedIsland = false;
        }
    }

    void GenerateNewLevel() {
        // find all level-specific items and delete them
        cannonBalls = GameObject.FindGameObjectsWithTag("CannonBall");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        
        foreach (GameObject _cannonBall in cannonBalls)
        {
            Destroy(_cannonBall);
        }

        foreach (GameObject _enemy in enemies)
        {
            Destroy(_enemy);
        }

        foreach (GameObject _obstacle in obstacles)
        {
            Destroy(_obstacle);
        }

        // randomly place player and island
        // randomly spawn an enemy and obstacle
        player.transform.position = new Vector3(Random.Range(0,10), Random.Range(0,10), 0);
        island.transform.position = new Vector3(Random.Range(11,20), Random.Range(11,20), 0);
        support.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 2, 0);
        Instantiate(enemy, new Vector3(Random.Range(0,10), Random.Range(0,10), 0), Quaternion.identity);
        Instantiate(obstacle, new Vector3(Random.Range(0,10), Random.Range(0,10), 0), Quaternion.identity);

    }



}
