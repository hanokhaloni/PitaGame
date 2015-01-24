using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour {
	// Use this for initialization
	public static int score;
	
	Text _text;
	
	
	void Awake () {
		_text = GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		_text.text = "Score " + score.ToString();
	}
}

