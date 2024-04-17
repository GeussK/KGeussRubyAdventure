using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class LossUIScript : MonoBehaviour
{

    public TMP_Text UILoss;
    public TMP_Text UITimer;
    public string displayLoss;
    public string timeRemainingString;
    public bool playerLose;
    public bool soundPlayed = false;

    [SerializeField] RubyController rubyController;

    public int duration = 30;
    public int timeRemaining = 30;
    public bool isCountingDown = false;
    public AudioClip loseSound;
    AudioSource audioSource;
    public void Begin()
    {
        
        if (!isCountingDown)
        {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("_tick", 1f);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void _tick()
    {
        timeRemaining--;
        if (timeRemaining >= 0)
        {
            Invoke("_tick", 1f);
        }
        else
        {
            isCountingDown = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        displayLoss = "";
        playerLose = false;
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeLoss()
    {
        if (timeRemaining != 0)
        {
            displayLoss = "You've lost! Press 'R' to restart!";
            playerLose = true;
            if (!soundPlayed)
            {
                PlaySound(loseSound);
                soundPlayed = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //int score = numberDestroyed;

        timeRemainingString = timeRemaining.ToString();

        if ( timeRemaining == 0 )
        {
            displayLoss = "You ran out of time! Press 'R' to restart!";
            playerLose = true;
            rubyController.WinSpeed();
            
        }

        UILoss.text = displayLoss;
        UITimer.text = "Time Left: " + timeRemainingString;
        if (Input.GetKey(KeyCode.R))

        {

            if (playerLose == true)

            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // this loads the currently active scene

            }

        }

    }
}
