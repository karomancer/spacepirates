// need to update destroy/generate functionality for all objects

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
    public GameObject enemyShooter;
    public GameObject enemyMover;
    public GameObject enemyFollower;
    public GameObject healer;
    public GameObject obstacle;
    public GameObject[] cannonBalls;
    public GameObject[] enemies;
    public GameObject[] obstacles;
    public GameObject[] movingEnemies;
    public GameObject[] shootingEnemies;
    public GameObject[] followingEnemies;
    public GameObject[] enemyProjectiles;
    public GameObject[] healers;


    public int xMin = -20;
    public int xMax = 20;
    public int yMin = -20;
    public int yMax = 20;

    public int numEnemies = 3;
    public int numEnemiesS = 3;
    public int numEnemiesM = 3;
    public int numEnemiesF = 3;
    public int numHealers = 2;
    public int numObstacles = 5;





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
        movingEnemies = GameObject.FindGameObjectsWithTag("EnemyMover");
        shootingEnemies = GameObject.FindGameObjectsWithTag("Enemy_Shooter");
        followingEnemies = GameObject.FindGameObjectsWithTag("EnemyFollower");
        enemyProjectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        healers = GameObject.FindGameObjectsWithTag("Healer");
        
        foreach (GameObject _cannonBall in cannonBalls)
        {
            Destroy(_cannonBall);
        }

        foreach (GameObject _enemy in enemies)
        {
            Destroy(_enemy);
        }

        foreach (GameObject _enemyM in movingEnemies)
        {
            Destroy(_enemyM);
        }

        foreach (GameObject _enemyS in shootingEnemies)
        {
            Destroy(_enemyS);
        }

        foreach (GameObject _enemyF in followingEnemies)
        {
            Destroy(_enemyF);
        }

        foreach (GameObject _enemyProjectile in enemyProjectiles)
        {
            Destroy(_enemyProjectile);
        }

        foreach (GameObject _obstacle in obstacles)
        {
            Destroy(_obstacle);
        }

        foreach (GameObject _healer in healers)
        {
            Destroy(_healer);
        }

        // randomly place player and island
        // randomly spawn an enemy and obstacle
        player.transform.position = new Vector3(Random.Range(0,10), Random.Range(0,10), 0);
        island.transform.position = new Vector3(Random.Range(11,20), Random.Range(11,20), 0);
        //support.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 2, 0);
        // Instantiate(enemy, new Vector3(Random.Range(0,10), Random.Range(0,10), 0), Quaternion.identity);
        // Instantiate(obstacle, new Vector3(Random.Range(0,10), Random.Range(0,10), 0), Quaternion.identity);
        // Instantiate(enemyShooter, new Vector3(Random.Range(0,10), Random.Range(0,10), 0), Quaternion.identity);
        // Instantiate(enemyMover, new Vector3(Random.Range(0,10), Random.Range(0,10), 0), Quaternion.identity);
        // Instantiate(healer, new Vector3(Random.Range(0,10), Random.Range(0,10), 0), Quaternion.identity);

        for (int i = 0; i < numEnemies; i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
        }

        for (int i = 0; i < numObstacles; i++)
        {
            Instantiate(obstacle, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
        }

        for (int i = 0; i < numEnemiesS; i++)
        {
            Instantiate(enemyShooter, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
            //Instantiate(enemyShooter, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.Euler(0,0,Random.Range(0,360)));
            
        }

        for (int i = 0; i < numEnemiesM; i++)
        {
            Instantiate(enemyMover, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
        }

        for (int i = 0; i < numEnemiesF; i++)
        {
            Instantiate(enemyFollower, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
        }

        for (int i = 0; i < numHealers; i++)
        {
            Instantiate(healer, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
        }
    }



}
