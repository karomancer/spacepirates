// need to update destroy/generate functionality for all objects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    public GameObject this_obstacle;
    public GameObject compass;

    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject asteroid4;

    public GameObject[] cannonBalls;
    public GameObject[] enemies;
    public GameObject[] obstacles;
    public GameObject[] movingEnemies;
    public GameObject[] shootingEnemies;
    public GameObject[] followingEnemies;
    public GameObject[] enemyProjectiles;
    public GameObject[] healers;
    public GameObject[] deliveries;
    public GameObject[] asteroid1s;
    public GameObject[] asteroid2s;
    public GameObject[] asteroid3s;
    public GameObject[] asteroid4s;

    public HealthBarScript healthBar;
    public GameObject delivery1;
    public GameObject delivery2;
    public GameObject delivery3;


    public int xMin = -70;
    public int xMax = 70;
    public int yMin = -70;
    public int yMax = 70;

    public int numEnemies = 3;
    public int numEnemiesS = 2;
    public int numEnemiesM = 2;
    public int numEnemiesF = 2;
    public int numHealers = 2;
    public int numObstacles = 5;

    public float difficultyLevel= 1f;
    public float difficultyInc = .3f;

    private Vector3 differenceVector;
    private float differenceFloat;
    private bool levelChangeSceneShowed = false;

    public AudioSource audioSource;
    public AudioClip hitIsland;
    public float volume = 0.5f;

    public AudioSource mainAudio;

    private int score = 0;
    private int scoreLength = 8;
    private int playerHealth;
    private int numDeliveries;
    string scoreString;
    int numZeros;
    string newScore;
    public GameObject textScriptHolder;
    public TMP_Text scoreText;

    public static bool paused = false;

    public GameObject pausePanel;
    public TMP_Text pauseText;

    string[] pauseTextOptions = {
        "Space parrots?? No no no I wanted space FERRETS!",
    "Thanks! Now I just need some space worms...",
    "African space chickens? I specifically asked for EUROPEAN ones!!",
    "Those boys from Space Fish and Wildlide give ya any trouble?",
    "Took ya long enough!",
    "Are these cage-free?"
    };

    private int randTextIndex;

    bool getNext;

    public TMP_Text newScoreText;
    private string _newScoreText;

    bool textStuffDone = false;





    //private PlayerController playerController;
    private PlayerController2 playerController;
    Playercontrols controls;

    void Awake()
    {
        // initialize player controls
        controls = new Playercontrols();
        // on button press, initialize next level if requirements have been met
        controls.Ship.Start.performed += ctx =>  GetNextLevel();
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        // get player and island. these objects are the same throughout

        //playerController = playerScriptHolder.GetComponent<PlayerController>();
        playerController = playerScriptHolder.GetComponent<PlayerController2>();
        player = GameObject.FindGameObjectWithTag("Player");
        island = GameObject.FindGameObjectWithTag("Island");

        // play main audio
        mainAudio.loop = true;
        mainAudio.Play();

        // set "next level text"
        randTextIndex = Random.Range(0, pauseTextOptions.Length);
        pauseText.text = pauseTextOptions[randTextIndex];
        
        // generate level 1
        GenerateNewLevel();


    }

    // Update is called once per frame
    void Update()
    {
        // below is all done when player hits the island
        if (playerController.reachedIsland == true)
        {
                // "pause" normal game
                Time.timeScale = 0f;
                paused = true;
                

                if (paused)
                {
                    // get in between level panel
                    pausePanel.SetActive(true);
                    // calculate score and display it (but only run this once)
                    if (!textStuffDone)
                        UpdateScore();
                        _newScoreText = "+ ";
                        _newScoreText += (numDeliveries * playerHealth).ToString();
                        _newScoreText += "points";
                        newScoreText.text = _newScoreText;
                        textStuffDone = true;
                    }
                    
                

                // once we hit the button to go to next level:
                if ((paused && getNext) || (paused && Input.GetKeyDown(KeyCode.Space)))
                {
                    // unpause game
                    pausePanel.SetActive(false);
                    Time.timeScale = 1;
                    paused = false;
                    getNext = false;
                }
                

                // once unpaused
                if (!paused)
                {
                    // generate new text and new level
                    textStuffDone = false;
                    print("generating new level");
                    randTextIndex = Random.Range(0, pauseTextOptions.Length);
                    pauseText.text = pauseTextOptions[randTextIndex];
                    playerController.reachedIsland = false;
                    GenerateNewLevel();

                }
            
        }
        // if player dies, go to gameover screen
        if (player == null)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void UpdateScore()
    {
        //playerHealth = playerScriptHolder.GetComponent<PlayerController>().playerHealth;
        //numDeliveries = playerScriptHolder.GetComponent<PlayerController>().numDeliveries;

        // calculate score based on health and deliveries
        playerHealth = playerScriptHolder.GetComponent<PlayerController2>().playerHealth;
        numDeliveries = playerScriptHolder.GetComponent<PlayerController2>().numDeliveries;
        score += ((numDeliveries+1) * playerHealth);
        scoreString = score.ToString();
        
        // get number of 0s needed for formatting
        numZeros = scoreLength - scoreString.Length;

        newScore = "";
        
        
        // format score string
        for(int i = 0; i < numZeros; i++)
        {
            newScore += "0";
        }
 
        // add score to end of 0s
        newScore += scoreString;
        scoreText.text = newScore;
        
    }

    void GetNextLevel()
    {
        // if we are paused and we hit yellow button, go to next level
        if (paused)
        {
            getNext = true;
        }
        
    }

    void GenerateNewLevel() {

        // heal player to full heatlh and make sure health bar matches

        // player.GetComponent<PlayerController>().Heal(100);
        // healthBar.SetHealth(player.GetComponent<PlayerController>().playerHealth);

        player.GetComponent<PlayerController2>().Heal(100);
        healthBar.SetHealth(player.GetComponent<PlayerController2>().playerHealth);

        // new level you have all 3 chickens to start
        delivery3.SetActive(true);
        delivery2.SetActive(true);
        delivery1.SetActive(true);
        //player.GetComponent<PlayerController>().numDeliveries = 3;
        player.GetComponent<PlayerController2>().numDeliveries = 3;

        // increase difficulty level
        difficultyLevel += difficultyInc;





        // find all level-specific items and delete them
        cannonBalls = GameObject.FindGameObjectsWithTag("CannonBall");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        movingEnemies = GameObject.FindGameObjectsWithTag("EnemyMover");
        shootingEnemies = GameObject.FindGameObjectsWithTag("EnemyShooterParent");
        followingEnemies = GameObject.FindGameObjectsWithTag("EnemyFollower");
        enemyProjectiles = GameObject.FindGameObjectsWithTag("EnemyProjectile");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        healers = GameObject.FindGameObjectsWithTag("Healer");
        deliveries = GameObject.FindGameObjectsWithTag("Delivery");
        
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

        foreach (GameObject _delivery in deliveries)
        {
            Destroy(_delivery);
        }


        // spawn player and island, but make sure they spawn sufficiently far from each other
        for (int i = 0; i <= 20; i++)
        {
            // player spawns at 0,0 with 0 rotation
            player.transform.position = new Vector3(0, 0, 0);
            player.transform.rotation = new Quaternion(0,0,0,0);
            // reset compass rotation to 0
            compass.transform.rotation = new Quaternion(0,0,0,0);
            compass.transform.Rotate(new Vector3(0,0,90));
            // place island randomly
            island.transform.position = new Vector3(Random.Range(xMin-2,xMax+2), Random.Range(yMin-2,yMax+2), 0);
            differenceVector = player.transform.position - island.transform.position;
            differenceFloat = differenceVector.x + differenceVector.y + differenceVector.z;
            if (Mathf.Abs(differenceFloat) > 15)
            {
                break;
            }
        }
        
        // spawn gameobjects for level
        
        for (int i = 0; i < (int) numObstacles * difficultyLevel; i++)
        {
            int randInt = Random.Range(0,4);
            if (randInt < 1)
            {
                this_obstacle = Instantiate(asteroid1, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
            }

            else if (randInt < 2)
            {
                this_obstacle = Instantiate(asteroid2, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
            }

            else if (randInt < 3)
            {
                this_obstacle = Instantiate(asteroid3, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
            }

            else
            {
                this_obstacle = Instantiate(asteroid4, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
            }

            this_obstacle.transform.Rotate(0,0,Random.Range(0,360));
        }

        for (int i = 0; i < (int) numEnemiesS * difficultyLevel; i++)
        {
            Instantiate(enemyShooter, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
        }

        for (int i = 0; i < (int) numEnemiesM * difficultyLevel; i++)
        {
            Instantiate(enemyMover, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
        }

        for (int i = 0; i < Mathf.Min(3,(int) numEnemiesF * difficultyLevel); i++)
        {
            Instantiate(enemyFollower, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
        }   

        for (int i = 0; i < (int) numHealers * difficultyLevel; i++)
        {
            Instantiate(healer, new Vector3(Random.Range(xMin,xMax), Random.Range(yMin,yMax), 0), Quaternion.identity);
        }
    }

    void OnEnable()
    {
        controls.Ship.Enable();
    }

    void OnDisable()
    {
        controls.Ship.Disable();
    }



}
