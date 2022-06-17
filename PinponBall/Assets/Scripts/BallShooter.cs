using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public event Action onBallShot;

    private MyGameManager myGameManager;
    public GameObject pinBall;

    private void Awake()
    {
        myGameManager = GameObject.Find("My Game Manager").GetComponent<MyGameManager>();
    }

    private void Update()
    {
        if (myGameManager.ballsRemain != 0)
        {
            Instantiate(pinBall);
            onBallShot?.Invoke();
        }
    }
}
