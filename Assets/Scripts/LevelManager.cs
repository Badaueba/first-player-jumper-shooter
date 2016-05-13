using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
		
	public int scoreToLevelUp;
	public int level;
	public int maxLevel = 3;
	public bool showLevelUp = false;
	ScoreFeedBack scoreFeedback;
	Score scoreManager;
	PlayerCol playerCol;
	public static LevelManager levelManager;

	void Awake () {
		if (levelManager == null) {
			DontDestroyOnLoad (gameObject);
			Debug.Log ("Dont destroy");
			levelManager = this;
		} else if (levelManager != this) {
			Destroy(this.gameObject);
			Debug.Log ("Destroy");
		}
		scoreManager = GameObject.FindObjectOfType<Score> ();
		scoreFeedback = GameObject.FindObjectOfType<ScoreFeedBack> ();
		playerCol = GameObject.FindObjectOfType<PlayerCol> ();
	}


	public IEnumerator LevelUp() {
		scoreFeedback.feedbackMessage.text = "Stage COMPLETED!\nLEVEL UP";
		level ++;
		scoreToLevelUp += scoreToLevelUp;
		scoreManager.SaveScore ();
		playerCol.DisablePlayer ();
		playerCol.enabled = false;
		Debug.Log ("LevelUP");
		yield return new WaitForSeconds(1.5f);
		showLevelUp = false;
		Application.LoadLevel (0);
	}
}
