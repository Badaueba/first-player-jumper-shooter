using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCol : MonoBehaviour {

	ScoreFeedBack scoreFeedback;

	public bool isDead;
	public bool isGrounded;
	void Awake() {
		scoreFeedback = GameObject.FindObjectOfType<ScoreFeedBack> ();
	}
	void OnTriggerEnter (Collider trig) {
		if (trig.gameObject.tag == "Obstacle") {
			StartCoroutine (PlayerDies (1f));
		}
	}
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Obstacle") {
			StartCoroutine( PlayerDies(1f));
		}
		if (col.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}

	public IEnumerator PlayerDies(float seconds) {
		scoreFeedback.feedbackMessage.text = "Restarting...";
		DisablePlayer ();

		isDead = true;
		yield return new WaitForSeconds (seconds);
		Application.LoadLevel (0);
	}
	public void DisablePlayer() {
		this.gameObject.GetComponent<PlayerJump> ().enabled = false;
		this.gameObject.GetComponent<PlayerMove> ().enabled = false;
	}
}
