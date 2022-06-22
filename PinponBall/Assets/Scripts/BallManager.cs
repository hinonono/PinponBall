using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
	public MyGameManager myGameManager;

	//public float ballOffset_y = 0.25f;
	//public float ballOffset_z = 0.4f;

	//判斷這顆球射出去了沒
	public bool isBallShot = false;
	//判斷這顆球有沒有效（經過彈跳區域）
	public bool isBallValid = false;

	private void Awake()
	{
		myGameManager = GameObject.Find("My Game Manager").GetComponent<MyGameManager>();

		myGameManager.uIManager.mainGameInterface.onPauseModalOpened += SetBallSwipeEnable;
		myGameManager.uIManager.mainGameInterface.onPauseModalClosed += SetBallSwipeDisable;
	}

    private void Start()
    {
		SetBallPosition();
	}

    private void Update()
    {
		SetBallPosition();
	}



	private void SetBallPosition()
	{

        if (isBallShot == false)
		{
            gameObject.transform.position = new Vector3(myGameManager.instantiateBallPostion.position.x, myGameManager.instantiateBallPostion.position.y, myGameManager.instantiateBallPostion.position.z);
		}
        else
        {
			return;
        }
	}

	private void SetBallSwipeEnable()
    {
		gameObject.GetComponent<BallSwipe>().enabled = true;
    }

	private void SetBallSwipeDisable()
    {
		gameObject.GetComponent<BallSwipe>().enabled = false;
	}


	private void OnDisable()
    {
		myGameManager.uIManager.mainGameInterface.onPauseModalOpened -= SetBallSwipeEnable;
		myGameManager.uIManager.mainGameInterface.onPauseModalClosed -= SetBallSwipeDisable;
	}

}
