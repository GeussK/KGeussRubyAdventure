using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class LossUIScript : MonoBehaviour
{

    public TMP_Text UILoss;
    public string displayLoss;
    public bool playerLose;

    // Start is called before the first frame update
    void Start()
    {
        displayLoss = "";
        playerLose = false;
    }

    public void ChangeLoss()
    {
        displayLoss = "You've lost! Press 'R' to restart!";
        playerLose = true;
    }

    // Update is called once per frame
    void Update()
    {
        //int score = numberDestroyed;

        UILoss.text = displayLoss;
        if (Input.GetKey(KeyCode.R))

        {

            if (playerLose == true)

            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // this loads the currently active scene

            }

        }
    }
}
