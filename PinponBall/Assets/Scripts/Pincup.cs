using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pincup : MonoBehaviour
{
    public event onScoreAreaEnteredDelegate onScoreAreaEntered;
    public delegate void onScoreAreaEnteredDelegate(int addScore);

    private GameObject scoreArea;

    //這個杯子的分數
    public int cupScore;

    private void Start()
    {
        scoreArea = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (cupScore != 0)
        {
            onScoreAreaEntered?.Invoke(cupScore);
        }
        else
        {
            Debug.Log("未設定杯子的分數");
        }
        
    }
}
