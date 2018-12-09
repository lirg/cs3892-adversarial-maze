using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallMover : MonoBehaviour {

    GameObject wall1_1;
    GameObject wall1_2;
    GameObject wall2_1;
    GameObject wall3_1;
    GameObject wall4_1;
    GameObject wall5_1;

    GameObject fountain;
    GameObject horse;
    GameObject lion;
    GameObject lamp;

    GameObject curMovingWall;

    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;
    Scene scene;
    string static_scene = "Static Condition";
    string dynamic_walls = "Dynamic Walls";
    string both_dynamic = "Dynamic LW";

    // Use this for initialization
    void Start () {
        wall1_1 = GameObject.Find("movablewall1_1");
        wall1_2 = GameObject.Find("movablewall1_2");
        wall2_1 = GameObject.Find("movablewall2_1");
        wall3_1 = GameObject.Find("movablewall3_1");
        wall4_1 = GameObject.Find("movablewall4_1");
        wall5_1 = GameObject.Find("movablewall5_1");
        fountain = GameObject.Find("Fountain_LW");
        lion = GameObject.Find("Lion_LW");
        lamp = GameObject.Find("CarvedLampPost_LW");
        horse = GameObject.Find("Horse_LW");
        startPosition = target = wall1_1.transform.position;
        curMovingWall = wall1_1;
        scene = SceneManager.GetActiveScene();
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

    private void TranslateZ(GameObject wall, float time, int distance) {
        t = 0;
        startPosition = wall.transform.position;
        timeToReachTarget = time;
        target = wall.transform.position;
        target.z += distance;
        curMovingWall = wall;
    }

    public void moveWalls(string name){
        scene = SceneManager.GetActiveScene();
        if (scene.name != static_scene) {
            switch(name){
                case "Pick Up 1":
                    StartCoroutine(move1());
                    break;
                case "Pick Up 2":
                    StartCoroutine(move2());
                    break;
                case "Pick Up 3":
                    StartCoroutine(move3());
                    break;
                case "Pick Up 4":
                    StartCoroutine(move4());
                    break;
                case "Pick Up 5":
                    StartCoroutine(move5());
                    break;
            }
        }
    }

    IEnumerator move1() {
        Debug.Log("Moving walls for pickup 1");
        TranslateY(wall1_1, 4, -25);
        yield return new WaitForSeconds(4);
        TranslateX(wall1_2, 3, 10);
        yield return new WaitForSeconds(3);
        if (scene.name == both_dynamic) {
            TranslateZ(fountain, 2, -25);
        }        
    }

    IEnumerator move2() {
        Debug.Log("Moving walls for pickup 2");
        if (scene.name == both_dynamic) {
            TranslateZ(lion, 1, -25);
            yield return new WaitForSeconds(1);
        }   
        TranslateY(wall2_1, 4, -25);
        yield return new WaitForSeconds(4);
    }

    IEnumerator move3() {
        Debug.Log("Moving walls for pickup 3");
        TranslateZ(wall3_1, 4, 8);
        yield return new WaitForSeconds(4);
        if (scene.name == both_dynamic) {
            TranslateX(lamp, 1, -55);
        }   
    }

    IEnumerator move4() {
        Debug.Log("Moving walls for pickup 4");
        TranslateX(wall4_1, 4, -10);
        yield return new WaitForSeconds(4);
        if (scene.name == both_dynamic) {
            TranslateX(horse, 1, -65);
            yield return new WaitForSeconds(1);
            TranslateZ(horse, 1, -20);
            yield return new WaitForSeconds(1);
        }   
    }

    IEnumerator move5() {
        Debug.Log("Moving walls for pickup 5");
        TranslateY(wall5_1, 4, -25);
        yield return new WaitForSeconds(4); 
    }
}
