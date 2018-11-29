using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour {

    GameObject wall1;

    GameObject curMovingWall;

    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;

    // Use this for initialization
    void Start () {
        wall1 = GameObject.Find("movablewall1");
        startPosition = target = wall1.transform.position;
        curMovingWall = wall1;
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime / timeToReachTarget;
        curMovingWall.transform.position = Vector3.Lerp(startPosition, target, t);
    }

    private void TranslateDown(GameObject wall, float time){
        t = 0;
        startPosition = wall.transform.position;
        timeToReachTarget = time;
        target = wall.transform.position;
        target.y -= 50;
        curMovingWall = wall;
    }

    public void moveWallDown(int wall){
        switch(wall){
            case 1:
                TranslateDown(wall1, 2);
                break;
        }
    }
}
