using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	Text scoreGUIText;
	Text highScoreGUIText;

	
	// Score
	private int score;
	
	// High Score
	private int highScore;
	
	// The key for saving with PlayerPrefs
	private string highScoreKey = "highScore";
	
	void Start ()
	{
		Initialize ();
	}
	
	void Update ()
	{
		// If the Score is higher than the High Score…
		if (highScore < score) {
			highScore = score;
		}
		
		// Display both the Score and High Score
		scoreGUIText.text = score.ToString ();
		highScoreGUIText.text = "HighScore : " + highScore.ToString ();
	}
	
	// Return to the original game state
	private void Initialize ()
	{
		scoreGUIText = GetComponent<Text>();
		highScoreGUIText = GetComponent<Text>();
		// Set the score to 0
		score = 0;
		
		// Retrieve the high score. If it can’t be received, use zero.
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}
	
	// Adding points
	public void AddPoint (int point)
	{
		score = score + point;
	}
	
	// Saving the High Score
	public void Save ()
	{
		// Save the high score
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();
		
		// Return to the original game state
		Initialize ();
	}
}