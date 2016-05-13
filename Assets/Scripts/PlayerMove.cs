using UnityEngine;
using System.Collections;



public class PlayerMove : MonoBehaviour {
	public int playerSpeed;
	Rigidbody rigidBody;

	void Awake() {
		rigidBody = GetComponent<Rigidbody> ();
	}
	void Update () {
		gameObject.transform.Translate (Vector3.right * playerSpeed * Time.deltaTime);
		Vector3 delta = Vector3.zero;
	
		delta.z = Input.GetAxis ("Horizontal");
		LeftAndRight (-delta);
	}

	void LeftAndRight (Vector3 delta) {
		rigidBody.transform.Translate (delta * playerSpeed * Time.deltaTime);
	}
}
