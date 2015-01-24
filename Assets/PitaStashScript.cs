using UnityEngine;
using System.Collections;

public class PitaStashScript : MonoBehaviour {

	public float aggroRange;
	public bool isAggro;
	public PlayerUpdateLocation target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;

		Vector3 playerLocation = target.transform.position;
		float distance = Vector3.Distance (currentPosition, playerLocation);
		Vector3 moveToward;
		isAggro = distance < aggroRange;
		
		if (isAggro) 
			target.addPitaCounter();

	}
}
