using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonARTesting : MonoBehaviour
{
    public GameObject myGameManager;

    private void Start()
    {
        myGameManager.GetComponent<MyGameManager>().InitializeBall();
    }
}
