using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	PlayerMove playerMove;
	PlayerCol playerCol;
	LevelManager levelManager;
	public int score;
	public int highScore { get; private set; }
	void Awake() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		playerMove = GameObject.FindObjectOfType<PlayerMove> ();
		playerCol = GameObject.FindObjectOfType<PlayerCol> ();
		LoadHighScore ();
	}
	void Update() {
		if (playerCol.isDead) 
			SaveScore ();
		else if (score >= levelManager.scoreToLevelUp 
			&& levelManager.level < levelManager.maxLevel) {

			this.StartCoroutine ( levelManager.LevelUp() );
		}

	}
	public void SaveScore () {
		if (this.score > LoadHighScore()) {
			PlayerPrefs.SetInt("HighScore", this.score);
		}
	}
	public int LoadHighScore() {
		highScore = PlayerPrefs.GetInt("HighScore", 0);
		return highScore;
	}
}
