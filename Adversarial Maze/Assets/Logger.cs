﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour {

    string path;
    System.IO.StreamWriter writer;

    // Use this for initialization
    void Start () {
        //path = "Assets/Resources/log_" + System.DateTime.Now + ".txt";
        path = "Assets/Resources/myLog.txt";
        writer = new System.IO.StreamWriter(path, true);
        writer.WriteLine(System.DateTime.Now + ":: Begin log file");
        writer.WriteLine("-----------------------------------------");
        writer.Close();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(System.DateTime.UtcNow + ":: cur time");
	}

    //Logs param time to log.txt file in Assets/Resources
    public void LogTime(string message, float time)
    {
        //Write to file
        writer.WriteLine(System.DateTime.Now + ":: " + message + " at time = " + time);
        writer.Close();
    }

}
