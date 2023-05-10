using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using TMPro;


public class GameManagerMainMenu : MonoBehaviour
{
    public AudioSource mainAudio;
    Playercontrols controls;
    public float flashTime = .3f;
    private float timeStampFlash;
    private GameObject lChicken;
    private GameObject rChicken;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new Playercontrols();
        controls.Ship.Start.performed += ctx =>  LoadInstructions();
    }
    
    
    void Start()
    {
        timeStampFlash = Time.time + flashTime;
        mainAudio.loop = true;
        mainAudio.Play();
        lChicken = GameObject.FindGameObjectWithTag("LChicken");
        rChicken = GameObject.FindGameObjectWithTag("RChicken");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Instructions");
        }

        if (timeStampFlash <= Time.time)
        {
            if (lChicken.activeSelf)
            {
            lChicken.SetActive(!gameObject.activeSelf);
            rChicken.SetActive(!gameObject.activeSelf);
            }
            else
            {
                lChicken.SetActive(gameObject.activeSelf);
                rChicken.SetActive(gameObject.activeSelf);
            }

            timeStampFlash = Time.time + flashTime;
        }
    }

    void LoadInstructions()
    {
       SceneManager.LoadScene("Instructions"); 
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
