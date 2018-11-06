using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    OVRCameraRig rig;
    Transform camTransform;

    Canvas canvas;

    public Text text;

    Timer timer;
    float timeLimit = 0;

    // Use this for initialization
    void Start () {
        rig = FindObjectOfType<OVRCameraRig>();
        camTransform = rig.centerEyeAnchor;

        canvas = FindObjectOfType<Canvas>();

        timer = this.transform.GetComponentInParent<Timer>();

    }
	
	// Update is called once per frame
	void Update () {
        // Shut off text when we've passed timeLimit

        float curTime = timer.getTime();
        if(timer.isEnabled() && curTime > timeLimit){
            timer.stopTimer();
            text.enabled = false;
        }
	}

    void toast(string message, float time){
        timer.resetTimer();
        timer.startTimer();
        timeLimit = time;
        text.text = message;
        text.enabled = true;
    }
}
