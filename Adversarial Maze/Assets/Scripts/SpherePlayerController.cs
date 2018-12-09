using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePlayerController : MonoBehaviour {

	public float speed;
	public HashSet<string> collectedPickUps;

	private Rigidbody rb;

    Logger logger;
    UI ui;
    WallMover wallmover;

	void Start() {
        collectedPickUps = new HashSet<string>();
		rb = GetComponent<Rigidbody>();
        logger = GameObject.Find("Utils").GetComponent<Logger>();
        ui = GameObject.Find("UI").GetComponent<UI>();
        wallmover = GameObject.Find("Utils").GetComponent<WallMover>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			collectedPickUps.Add(other.gameObject.name);

            // wallmover.moveWallDown(1);
            int count = collectedPickUps.Count;
            ui.toast("Object " + count + " found!", 3);
            logger.Log("Object " + count + " found", 0);
		}
	}
}
