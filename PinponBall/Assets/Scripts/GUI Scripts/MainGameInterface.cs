using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameInterface : MonoBehaviour
{
    private MyGameManager myGameManager;

    [SerializeField]
    private GameObject pauseModal;
    [SerializeField]
    private TextMeshProUGUI scoreText, remainBallText;
    [SerializeField]
    private GameObject sftAlert;
    

    private void OnEnable()
    {
        myGameManager = GameObject.Find("My Game Manager").GetComponent<MyGameManager>();
        myGameManager.OnSFTStarted += ShowSFTAlert;
    }

    private void Update()
    {
        scoreText.text = myGameManager.gameScore.ToString();
        remainBallText.text = myGameManager.ballsRemain.ToString();
    }

    public void TogglePauseModal()
    {
        pauseModal.SetActive(!pauseModal.activeSelf);
    }

    private void ShowSFTAlert()
    {
        sftAlert.SetActive(true);
    }

    private void OnDisable()
    {
        myGameManager.OnSFTStarted -= ShowSFTAlert;
    }
}
