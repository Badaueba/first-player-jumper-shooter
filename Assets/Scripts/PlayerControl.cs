using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float jetPackFuel; 
	public float jetPackForce;
	public Rigidbody rb;

	void Update () {
		if (Input.GetButton ("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ) {
			if (jetPackFuel > 0)
				BoostUp ();
		} 

	}

	void BoostUp () {
		jetPackFuel = Mathf.MoveTowards (jetPackFuel, 0, Time.deltaTime);
		rb.AddForce (new Vector3 (0, jetPackForce, 0));
		rb.transform.Translate( new Vector3(0, Time.deltaTime * jetPackForce, 0));
		Debug.Log ("rigdbody : " + rb);
	}

	void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Ground") {
			if (jetPackFuel < 1.5f  ) {
				jetPackFuel = Mathf.MoveTowards(jetPackFuel, 1.5f, Time.fixedDeltaTime);
			}
		}
	}

}
