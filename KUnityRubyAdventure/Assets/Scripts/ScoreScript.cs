using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreScript : MonoBehaviour  
{
    
    public TMP_Text UIScore;
    public int numberDestroyed;
    [SerializeField] WinUiScript winUiScript;
    [SerializeField] RubyController rubyController;
    // Start is called before the first frame update
    void Start()
    {
        numberDestroyed = 0;
    }

    public void ChangeScore()
    {
        numberDestroyed++;
    }

    // Update is called once per frame
    void Update()
    {
        //int score = numberDestroyed;
        
        UIScore.text = "Robots Fixed:" + numberDestroyed.ToString();
        if (numberDestroyed == 4)
        {
            winUiScript.ChangeWin();
            rubyController.WinSpeed();
        }
    }
}
