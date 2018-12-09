using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialBar : MonoBehaviour {

    public Image LoadingBar;
    public Image LoadingBarCenter;
    float currentValue = 0;
    float speed = 50;

    bool filling = false;

    public void startFill(){
        filling = true;
        currentValue = 0;
    }

    public void stopFill(){
        filling = false;
        currentValue = 0;
        LoadingBar.fillAmount = 0;
        LoadingBarCenter.fillAmount = 0;
    }

    public bool filled(){
        return currentValue >= 100;
    }

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (currentValue < 100 && filling)
        {
            currentValue += speed * Time.deltaTime;
        }
        else
        {

        }

        LoadingBar.fillAmount = currentValue / 100;
        LoadingBarCenter.fillAmount = currentValue / 100;
    }
}
