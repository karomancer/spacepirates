using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class GameManagerLevelChange : MonoBehaviour
{
    
    Playercontrols controls;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new Playercontrols();
        controls.Ship.Start.performed += ctx =>  LoadNextLevel();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }

    void LoadNextLevel()
    {
       SceneManager.LoadScene("Game"); 
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
