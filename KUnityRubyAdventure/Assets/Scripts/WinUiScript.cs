using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class WinUiScript : MonoBehaviour
{

    public TMP_Text WinUI;
    public string displayWin;
    public AudioClip winSound;
    public bool soundPlayed = false;
    AudioSource audioSource;
    public bool chicken = false;
    public bool robot = false;
    [SerializeField] RubyController rubyController;
    [SerializeField] LossUIScript lossUIScript;

    // Start is called before the first frame update

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void Start()
    {
        displayWin = "";
        audioSource = GetComponent<AudioSource>();
    }

    public void Chicken()
    {
        chicken = true;
    }
    public void Robot()
    {
        robot = true;
    }

    public void ChangeWin()
    {
        if (chicken && robot)
        {
            displayWin = "You've won! Press Escape to Quit Game made by Kyle and Joshua";
            if (!soundPlayed)
            {
                PlaySound(winSound);
                soundPlayed = true;
            }
            rubyController.WinSpeed();
            lossUIScript.playerWon();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //int score = numberDestroyed;

        WinUI.text = displayWin;
        
    }
}
