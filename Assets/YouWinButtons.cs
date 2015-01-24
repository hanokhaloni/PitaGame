using UnityEngine;
using System.Collections;

public class YouWinButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void QuitClick() {
		Application.Quit ();
	}

	public void PlayAgain() {
		Application.LoadLevel ("MainGame");
		}
}