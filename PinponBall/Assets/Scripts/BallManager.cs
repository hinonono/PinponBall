using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
	public MyGameManager myGameManager;

	private Transform cameraPos;
	private float ballOffset_y = 0.25f;
	private float ballOffset_z = 0.4f;

	//判斷這顆球射出去了沒
	public bool isBallShot = false;
	//判斷這顆球有沒有效（經過彈跳區域）
	public bool isBallValid = false;

	private void Awake()
	{
		myGameManager = GameObject.Find("My Game Manager").GetComponent<MyGameManager>();
	}

    private void Start()
    {
		cameraPos = Camera.main.transform;
		SetBallPosition();
	}

    private void Update()
    {
		SetBallPosition();
	}

	private void SetBallPosition()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			return;
		}
		else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			return;
		}
		else if (isBallShot)
		{
			return;
		}
		else
		{
            gameObject.transform.position = new Vector3(cameraPos.position.x, cameraPos.position.y - ballOffset_y, cameraPos.position.z + ballOffset_z);
		}
	}

}
