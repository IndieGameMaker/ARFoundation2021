using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacerMgr : MonoBehaviour
{
    public GameObject mummyPrefab;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private ARRaycastManager raycastManager;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            if (raycastManager.Raycast(touch.position, hits, TrackableType.All))
            {
                GameObject obj = Instantiate(mummyPrefab,
                                             hits[0].pose.position,
                                             hits[0].pose.rotation);
            }
        }
    }
}
