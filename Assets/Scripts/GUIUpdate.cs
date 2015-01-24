using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIUpdate : MonoBehaviour {
	// Use this for initialization
	Text pitaCounterText;
	public void setText(string text) {
		pitaCounterText.text = text;
		}
	void Start () {
		pitaCounterText = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

	}
}
