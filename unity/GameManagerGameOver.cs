using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class GameManagerGameOver : MonoBehaviour
{
    public AudioSource mainAudio;

    Playercontrols controls;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new Playercontrols();
        controls.Ship.Start.performed += ctx =>  LoadMainMenu();
    }
    // Start is called before the first frame update
    void Start()
    {
        mainAudio.loop = true;
        mainAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void LoadMainMenu()
    {
       SceneManager.LoadScene("MainMenu"); 
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
