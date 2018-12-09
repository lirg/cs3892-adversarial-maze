using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelecter : MonoBehaviour {

    OVRCameraRig rig;
    Transform camTransform;

    HashSet<string> colliderTags;

    int range = 1000;

    // Use this for initialization
    void Start () {
        rig = FindObjectOfType<OVRCameraRig>();
        camTransform = rig.centerEyeAnchor;

        colliderTags = new HashSet<string>();
        colliderTags.Add("homeButtonStatic");
        colliderTags.Add("homeButtonDynamicWalls");
        colliderTags.Add("homeButtonDynamicLandmarks");
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
            if(hit.collider.tag == "homeButtonStatic"){
                Debug.Log(hit.collider.tag);
            }
            else if(hit.collider.tag == "homeButtonDynamicLandmarks"){
                Debug.Log(hit.collider.tag);
            }
            else if(hit.collider.tag == "homeButtonDynamicWalls"){
                Debug.Log(hit.collider.tag);
            }
        }
    }
}
