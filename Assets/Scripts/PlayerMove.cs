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

		float axis = Input.GetAxis ("Horizontal");
		if (axis != 0.00f)
			LeftAndRight (axis);
	}

	void LeftAndRight (float z) {
		rigidBody.transform.Translate (new Vector3 (0, 0, -z * playerSpeed * Time.deltaTime));
	}
}
