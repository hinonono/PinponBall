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

    public Transform instantiateBallPostion;
    public GameObject ball;
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

    public void RecaculateBall()
    {
        ballsRemain = ballsPerPlay - ballsUsed;

        if (ballsRemain > 0)
        {
            StartCoroutine(InstantiateDelay());
            InitializeBall();
        }
    }

    public void InitializeBall()
    {
        //建立一個獨立的pos避免球被生成為子物件
        Vector3 pos = instantiateBallPostion.transform.position;
        //當Ground plane找到以後初始化球
        Instantiate(ball, pos, Quaternion.identity);
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

    IEnumerator InstantiateDelay()
    {
        //替球的生成加上1秒的延遲
        yield return new WaitForSeconds(1);
    }
}
