using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkFinder : MonoBehaviour {

    OVRCameraRig rig;
    Transform camTransform;

    Logger logger;
    Timer timer;

    HashSet<string> colliderTags;
    HashSet<string> curLookObj;

    //20 magic unity units
    float range = 300;

	// Use this for initialization
	void Start () {

        rig = FindObjectOfType<OVRCameraRig>();
        camTransform = rig.centerEyeAnchor;

        colliderTags = new HashSet<string>();
        curLookObj = new HashSet<string>();

        //add tags here
        colliderTags.Add("box");

        logger = this.transform.GetComponentInParent<Logger>();
        timer = this.transform.GetComponentInParent<Timer>();

        timer.startTimer();

	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        camTransform = rig.centerEyeAnchor; //update cam direction
        Vector3 rayDirection = camTransform.TransformDirection(Vector3.forward);
        Vector3 rayStart = camTransform.position + rayDirection;     
        Debug.DrawRay(rayStart, rayDirection * range, Color.green);
        if (Physics.Raycast(rayStart, rayDirection, out hit, range))
        {
            curLookObj.Clear();
            curLookObj.Add(hit.collider.tag);
            curLookObj.IntersectWith(colliderTags);
            if(curLookObj.Count > 0){   //found landmark
                logger.LogTime("Landmark " + hit.collider.tag + " found", 
                               timer.getTime());
            }
        }
    }
}
