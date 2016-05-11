using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
 
	public float jumpForce;
	public bool onGround = true;
	Rigidbody rigidBody;
	void Awake() {
		rigidBody = GetComponent<Rigidbody> ();
	}
	void FixedUpdate () {
		if (Input.GetButton ("Jump") || 
			(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)) {
			if (onGround) 
				Jump ();
		}
	}
	void Jump () {
		rigidBody.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
		onGround = false;
	}

}
