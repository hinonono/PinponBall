using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSwipe : MonoBehaviour
{
	Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

	[SerializeField]
	float throwForceInX = 1f;
	[SerializeField]
	float throwForceInY = 1f;
	[SerializeField]
	float maxThrowForceInY = 150f;
	[SerializeField]
	float throwForceInZ = 50f;

	Rigidbody rb;
	private Camera mainCam; 

	private BallManager ballManager;

	private void Start()
	{
		ballManager = GetComponent<BallManager>();
		rb = GetComponent<Rigidbody>();
		mainCam = Camera.main;
	}

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
			//rb.AddForce(-direction.x * throwForceInX, -direction.y * throwForceInY <= maxThrowForceInY ? -direction.y * throwForceInY : maxThrowForceInY, throwForceInZ / timeInterval);
			//rb.AddRelativeForce(mainCam.transform.forward.x * throwForceInX, mainCam.transform.forward.y * throwForceInY <= maxThrowForceInY ? mainCam.transform.forward.y * throwForceInY : maxThrowForceInY, mainCam.transform.forward.z * throwForceInZ, ForceMode.Force);
			rb.AddForce(mainCam.transform.forward * throwForceInZ);


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
            // Destroy ball in 10 seconds
            Destroy(gameObject, 10f);

		}

	}
}
