using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneDetectionController : MonoBehaviour
{
    private ARPlaneManager aRPlaneManager;
    [SerializeField]
    private ARCursor aRCursor;

    private void Awake()
    {
        aRPlaneManager = gameObject.GetComponent<ARPlaneManager>();
    }

    private void OnEnable()
    {
        aRCursor.OnObjectPlaced += stopPlaneDetection;
    }

    private void OnDisable()
    {
        aRCursor.OnObjectPlaced -= stopPlaneDetection;
    }

    private void stopPlaneDetection()
    {
        aRPlaneManager.enabled = false;
        aRCursor.enabled = false;
    }

    public void StartPlaneDetection()
    {
        aRPlaneManager.enabled = true;
        aRCursor.enabled = true;
    }
}
