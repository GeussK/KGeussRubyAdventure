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

    // Start is called before the first frame update
    void Start()
    {
        displayWin = "";
    }

    public void ChangeWin()
    {
        displayWin = "You've won! Press Escape to Quit Game made by Kyle and Joshua";
    }

    // Update is called once per frame
    void Update()
    {
        //int score = numberDestroyed;

        WinUI.text = displayWin;
        
    }
}
