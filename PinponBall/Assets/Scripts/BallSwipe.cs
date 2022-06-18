using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSwipe : MonoBehaviour
{
	Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

	[SerializeField]
	float throwForceInX = 1f; // to control throw force in X and Y directions

	[SerializeField]
	float throwForceInY = 1f;

	[SerializeField]
	float throwForceInZ = 10f; // to control throw force in Z direction

	Rigidbody rb;

	private BallManager ballManager;

	private void Start()
	{
		ballManager = GetComponent<BallManager>();
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	private void Update()
	{
		
		// if you touch the screen
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{

			// getting touch position and marking time when you touch the screen
			touchTimeStart = Time.time;
			startPos = Input.GetTouch(0).position;
		}

		// if you release your finger
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{

			// marking time when you release it
			touchTimeFinish = Time.time;

			// calculate swipe time interval 
			timeInterval = touchTimeFinish - touchTimeStart;

			// getting release finger position
			endPos = Input.GetTouch(0).position;

			// calculating swipe direction in 2D space
			direction = startPos - endPos;

			// add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
			rb.isKinematic = false;
			rb.AddForce(-direction.x * throwForceInX, -direction.y * throwForceInY, throwForceInZ / timeInterval);


			ballManager.isBallShot = true;

            if (ballManager.myGameManager.ballsUsed < ballManager.myGameManager.ballsPerPlay)
            {
				ballManager.myGameManager.ballsUsed += 1;
			}

			if (ballManager.myGameManager.ballsRemain > 0)
			{
				ballManager.myGameManager.RecaculateBall();
			}

			gameObject.GetComponent<BallSwipe>().enabled = false;
            // Destroy ball in 4 seconds
            Destroy(gameObject, 15f);

		}

	}
}
