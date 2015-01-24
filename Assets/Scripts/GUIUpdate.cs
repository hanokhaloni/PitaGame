using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIUpdate : MonoBehaviour {
	// Use this for initialization
	public static int pitaCount;

	Text _text;


	void Awake () {
		_text = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		_text.text = pitaCount.ToString();
	}
}
