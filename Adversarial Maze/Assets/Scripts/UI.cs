using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    OVRCameraRig rig;
    Transform camTransform;

    Canvas canvas;

    // Use this for initialization
    void Start () {
        rig = FindObjectOfType<OVRCameraRig>();
        camTransform = rig.centerEyeAnchor;

        canvas.transform.parent = rig.transform;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
