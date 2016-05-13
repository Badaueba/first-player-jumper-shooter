using UnityEngine;
using System.Collections;


public class PlayerJump : MonoBehaviour {
 
	public float jumpForce;
	public bool onGround = true;
	Rigidbody rigidBody;
	PlayerCol col;
	void Awake() {
		rigidBody = GetComponent<Rigidbody> ();
		col = transform.GetComponent<PlayerCol> ();
	}
	void FixedUpdate () {

		if (Input.GetButton ("Jump") || 
			(Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)) {
			if (col.isGrounded) 
				Jump ();
		}
	}
	void Jump () {
		rigidBody.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
		col.isGrounded = false;
	}

}
