using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanningInstrustion : MonoBehaviour
{
    //給予玩家AR掃描時的提示
    private ARFilteredPlane aRFilteredPlane;
    private ARCursor aRCursor;
    private Text instructionText;

    private void OnEnable()
    {
        aRFilteredPlane = gameObject.GetComponent<ARFilteredPlane>();
        aRFilteredPlane.OnHorizontalPlaneFound += PlaneFound;

        aRCursor = GameObject.Find("AR Cursor").GetComponent<ARCursor>();
        aRCursor.OnObjectPlaced += ObjectPlaced;

        instructionText = gameObject.GetComponentInChildren<Text>();
    }

    private void PlaneFound()
    {
        instructionText.text = "觸摸畫面上的紅點來放置球台";
    }

    private void ObjectPlaced()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        aRFilteredPlane.OnHorizontalPlaneFound -= PlaneFound;
        aRCursor.OnObjectPlaced -= ObjectPlaced;
    }
}
