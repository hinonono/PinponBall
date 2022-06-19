using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARFilteredPlane : MonoBehaviour
{

    [SerializeField] private Vector2 dimensionsForBigPlane = new Vector2(0.3f, 0.3f);

    public event Action OnVerticalPlaneFound;
    public event Action OnHorizontalPlaneFound;
    public event Action OnBigPlaneFound;

    private ARPlaneManager aRPlaneManager;
    private List<ARPlane> aRPlanes;

    private void OnEnable()
    {
        aRPlanes = new List<ARPlane>();
        aRPlaneManager = FindObjectOfType<ARPlaneManager>();
        aRPlaneManager.planesChanged += onPlanesChanged;
    }

    private void OnDisable()
    {
        aRPlaneManager.planesChanged -= onPlanesChanged;
    }

    private void onPlanesChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && args.added.Count > 0)
        {
            aRPlanes.AddRange(args.added);
        }

        foreach (ARPlane plane in aRPlanes.Where(plane => plane.extents.x * plane.extents.y >= 0.1f))
        {
            if (plane.alignment.IsVertical())
            {
                //vertical plane
                OnVerticalPlaneFound.Invoke();
            }
            else
            {
                //horizontal plane
                OnHorizontalPlaneFound.Invoke();
            }

            if (plane.extents.x * plane.extents.y >= dimensionsForBigPlane.x * dimensionsForBigPlane.y)
            {
                //big plane
                OnBigPlaneFound.Invoke();
            }
        }
    }
}
