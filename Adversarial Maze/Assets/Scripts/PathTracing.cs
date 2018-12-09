using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTracing : MonoBehaviour {


    private List<Vector3> playerPositions;
    bool printedMaze;

	// Use this for initialization
	void Start () {
        playerPositions = new List<Vector3>();
        printedMaze = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!printedMaze)
        {
            playerPositions.Add(GameObject.Find("LocalAvatar").transform.position);
        }
        if (PlayerFinishedMaze() && !printedMaze){
            Color red = Color.red;
            LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
            lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
            lineRenderer.startColor = red;
            lineRenderer.endColor = red;
            lineRenderer.startWidth = 0.2F;
            lineRenderer.endWidth = 0.2F;

            //Change how mant points based on the mount of positions is the List
            lineRenderer.positionCount = playerPositions.Count;

            for (int i = 0; i < playerPositions.Count; i++)
            {
                //Change the postion of the lines
                lineRenderer.SetPosition(i, playerPositions[i]);
            }
            saveImageOfPath();
            printedMaze = true;

        }
    }

    bool PlayerFinishedMaze(){
        GameObject controller = GameObject.Find("OVRPlayerController");
        return controller.GetComponent<OVRPlayerController>().collectedPickUps.Count == 5;
    }

    void saveImageOfPath(){
        return;
    }
    



}
