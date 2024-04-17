using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ChickenScoreScript : MonoBehaviour
{
    public TMP_Text UIScore;
    public int chickenCollect;
    [SerializeField] WinUiScript winUiScript;
    
    // Start is called before the first frame update
    void Start()
    {
        chickenCollect = 0;

    }

    public void ChangeScore()
    {
        chickenCollect++;
    }

    // Update is called once per frame
    void Update()
    {
        //int score = numberDestroyed;

        UIScore.text = "Chickens Collected:" + chickenCollect.ToString();
        if (chickenCollect == 3)
        {
            winUiScript.ChangeWin();
            winUiScript.Chicken();
        }
    }
}
