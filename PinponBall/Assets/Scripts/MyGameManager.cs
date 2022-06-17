using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{

    public int gameScore = 0;
    public int scoreMultiply = 1;

    public int ballsPerPlay = 10;
    public int ballsRemain;

    private GameObject[] pinCups;

    // Start is called before the first frame update
    void Start()
    {
        ballsRemain = ballsPerPlay;
        pinCups = GameObject.FindGameObjectsWithTag("Cups");

        if (pinCups != null)
        {
            foreach (var pincup in pinCups)
            {
                pincup.GetComponentInChildren<Pincup>().onScoreAreaEntered += AddScore;
            }
        }
    }

    private void AddScore(int addScore)
    {
        gameScore += addScore;
    }

    private void OnApplicationQuit()
    {
        if (pinCups != null)
        {
            foreach (var pincup in pinCups)
            {
                pincup.GetComponentInChildren<Pincup>().onScoreAreaEntered -= AddScore;
            }
        }
    }
}
