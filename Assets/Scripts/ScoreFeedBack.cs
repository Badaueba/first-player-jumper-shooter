using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreFeedBack : MonoBehaviour {

	Text scoreText;
	Text hScoreText;
	Text levelText;
	Text scoreToLevelUpText;
	public Text feedbackMessage;
	Score scoreManager;
	LevelManager levelManager;

	void Awake() {
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
		hScoreText = GameObject.Find ("HighScoreText").GetComponent<Text>();
		scoreToLevelUpText = GameObject.Find ("ScoreToLevelUpText").GetComponent<Text>();
		levelText = GameObject.Find ("LevelText").GetComponent<Text>();
		feedbackMessage = GameObject.Find ("FeedbackMessage").GetComponent<Text>();
		scoreManager = GameObject.FindObjectOfType<Score> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	void Update () {
		scoreText.text = "Score: " + scoreManager.score;
		hScoreText.text = "High Score: " + scoreManager.highScore;
		levelText.text = "Level: " + levelManager.level;
		scoreToLevelUpText.text = "Task: " + scoreManager.score + "/" + levelManager.scoreToLevelUp;
	}

}

