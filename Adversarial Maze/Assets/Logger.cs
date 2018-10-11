using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Logs param time to log.txt file in Assets/Resources
    void LogTime(float time)
    {
        string path = "Assets/Resources/log.txt";

        //Write to file
        System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true);
        writer.WriteLine(System.DateTime.Now + ":: Time = " + time);
        writer.Close();
    }

}
