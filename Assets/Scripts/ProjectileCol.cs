using UnityEngine;
using System.Collections;

public class ProjectileCol : MonoBehaviour {
	Score scoreManager;
	void Awake () {
		scoreManager = GameObject.FindObjectOfType<Score> ();
	}
	void OnCollisionEnter (Collision col ) {
		if (col.transform.tag == "Obstacle") {
			Destroy (col.transform.gameObject);
			scoreManager.score ++;
		}
		Destroy (this.gameObject);
	}
}
