using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	public int playerSpeed;
	public Rigidbody rb;
	public float zSpeed = 10f;


	void Update () {
		float z = Input.GetAxis ("Horizontal");
		
		if (z != 0.00f)
			LeftAndRight (z);
		gameObject.transform.Translate (Vector3.right * playerSpeed * Time.deltaTime);
	}

	void LeftAndRight (float z) {
		/*if (rb.transform.position.z > zLimit) {
			rb.transform.position = new Vector3 (0, 0, zLimit);
			return;
		} else if (rb.transform.position.z < (-zLimit)) {
			rb.transform.position = new Vector3 (0, 0, -zLimit);
			return;
		}
		else 
			*/
		rb.transform.Translate (new Vector3 (0, 0, -z * zSpeed * Time.deltaTime));
	}
}
