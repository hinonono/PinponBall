using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject scanModal;
    [SerializeField]
    private GameObject startScanningModal;
    [SerializeField]
    private GameObject mainGameInterfaceObj;

    public MainGameInterface mainGameInterface;

    private ARCursor aRCursor;


    private void OnEnable()
    {
        aRCursor = GameObject.Find("AR Cursor").GetComponent<ARCursor>();
        aRCursor.OnObjectPlaced += ObjectPlaced;

        mainGameInterface = mainGameInterfaceObj.GetComponent<MainGameInterface>();
    }

    public void ObjectPlaced()
    {
        mainGameInterfaceObj.SetActive(true);
    }

    public void DismissScanModal()
    {
        scanModal.SetActive(false);
    }

    public void ShowStartScanningModal()
    {
        startScanningModal.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Scene name is null. Cannot load scene.");
        }
    }
}
