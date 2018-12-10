using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISelecter : MonoBehaviour {

    OVRCameraRig rig;
    Transform camTransform;

	public Button button1, button2, button3;

    HashSet<string> colliderTags;
    string cur = null;
    string prev = null;

    RadialBar rb;

    int range = 1000;

    // Use this for initialization
    void Start () {
        rig = FindObjectOfType<OVRCameraRig>();
        camTransform = rig.centerEyeAnchor;
        rb = FindObjectOfType<RadialBar>();

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
            prev = cur;
            if (colliderTags.Contains(hit.collider.tag)){
                cur = hit.collider.tag;
				switch (cur)
				{
				//switch scenes
				case "homeButtonStatic":
					button1.Select();
					break;
				case "homeButtonDynamicWalls":
					button2.Select();
					break;
				case "homeButtonDynamicLandmarks":
					button3.Select();
					break;
				}
                if (cur != prev)
                {
                    rb.startFill();
                }
                if (cur == prev)
                {
                    if (rb.filled())
                    {
                        switch (cur)
                        {
                            //switch scenes
                            case "homeButtonStatic":
                                SceneManager.LoadScene("Static Condition", LoadSceneMode.Single);
                                break;
                            case "homeButtonDynamicWalls":
                                SceneManager.LoadScene("Dynamic Walls", LoadSceneMode.Single);
                                break;
                            case "homeButtonDynamicLandmarks":
                                SceneManager.LoadScene("Dynamic LW", LoadSceneMode.Single);
                                break;
                        }
                    }
                }
            }
            else{
                rb.stopFill();
                cur = null;
                prev = null;
            }
        }
        else
        {
            rb.stopFill();
            cur = null;
            prev = null;
        }
    }
}
