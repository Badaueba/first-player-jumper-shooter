using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCol : MonoBehaviour {

	
	void OnTriggerEnter (Collider trig) {
		if (trig.gameObject.tag == "Coin") {
			Destroy(trig.gameObject);
		}
		if (trig.gameObject.tag == "Obstacle") {
			StartCoroutine( PlayerDies(1f));
		}
		if (trig.gameObject.tag == "End") {
			Debug.Log ("End");
			Text finishText = GameObject.Find("Feedback").GetComponent<Text>();
			finishText.text = "Finished!";
			Image crosshair = GameObject.Find ("Crosshair").GetComponent<Image>();
			crosshair.enabled = false;

			StartCoroutine( PlayerDies(3f));
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Obstacle") {
			StartCoroutine( PlayerDies(1f));
		}
	
	}
	
	IEnumerator PlayerDies(float seconds) {
		this.gameObject.GetComponent<PlayerControl> ().enabled = false;
		this.gameObject.GetComponent<PlayerMove> ().enabled = false;
		yield return new WaitForSeconds (seconds);
		//Text finishText = GameObject.Find("Feedback").GetComponent<Text>();
		//finishText.text = "Restarting!";
		//activate UI for restarting
		Application.LoadLevel (0);
	}
}
