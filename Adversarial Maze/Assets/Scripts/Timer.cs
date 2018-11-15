using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    private bool isTiming = false;
    private float time = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (isTiming)
        {
            time += Time.deltaTime;
        }
	}

    public float getTime(){
        return time;
    }

    public void startTimer(){
        isTiming = true;
    }

    public void stopTimer(){
        isTiming = false;
    }

    public void resetTimer(){
        stopTimer();
        time = 0;
    }

    public bool isEnabled(){
        return isTiming;
    }
}
