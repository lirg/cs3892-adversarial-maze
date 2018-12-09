using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour {

    GameObject wall1_1;
    GameObject wall1_2;

    GameObject curMovingWall;

    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;

    // Use this for initialization
    void Start () {
        wall1_1 = GameObject.Find("movablewall1_1");
        wall1_2 = GameObject.Find("movablewall1_2");
        startPosition = target = wall1_1.transform.position;
        curMovingWall = wall1_1;
        Debug.Log("Started wallmover");
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime / timeToReachTarget;
        curMovingWall.transform.position = Vector3.Lerp(startPosition, target, t);
    }

    private void TranslateY(GameObject wall, float time, int distance){
        t = 0;
        startPosition = wall.transform.position;
        timeToReachTarget = time;
        target = wall.transform.position;
        target.y += distance;
        curMovingWall = wall;
    }

    private void TranslateX(GameObject wall, float time, int distance) {
        t = 0;
        startPosition = wall.transform.position;
        timeToReachTarget = time;
        target = wall.transform.position;
        target.x += distance;
        curMovingWall = wall;
    }

    public void moveWalls(string name){
        switch(name){
            case "Pick Up 1":
                Debug.Log("Moving walls for pickup 1");
                TranslateY(wall1_1, 5, -25);
                TranslateX(wall1_2, 5, 10);
                break;
        }
    }
}
