using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{

    public int gameScore = 0;
    public bool isSuperFeverTime = false;
    public int scoreMultiply = 1;

    public int ballsPerPlay = 10;
    public int ballsUsed;
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

    private void Update()
    {
        if (ballsRemain == 1)
        {
            isSuperFeverTime = true;
        }

        if (isSuperFeverTime)
        {
            scoreMultiply = 10;
        }
    }

    private void useBall()
    {
        ballsUsed += 1;
        ballsRemain = ballsPerPlay - ballsUsed;
    }

    public void recaculateBall()
    {
        ballsRemain = ballsPerPlay - ballsUsed;
    }

    private void AddScore(int addScore)
    {
        gameScore = gameScore + (addScore * scoreMultiply);
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
