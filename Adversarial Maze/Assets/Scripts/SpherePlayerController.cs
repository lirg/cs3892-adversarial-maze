using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePlayerController : MonoBehaviour {

	public float speed;
	public HashSet<string> collectedPickUps;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
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
		}
	}
}
