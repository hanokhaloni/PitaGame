using UnityEngine;
using System.Collections;

public class EvemyScriipt : MonoBehaviour {
	public float moveSpeed;
	public float turnSpeed;
	private Vector3 moveDirection;
	public float aggroRange;
	public bool isAggro;

	//var target = PlayerUpdateLocation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;
		// 2
		// 3
		var playerObject = GameObject.Find("Player");
		Vector3 playerLocation = playerObject.transform.position;
		float distance = Vector3.Distance (currentPosition, playerLocation);
		Vector3 moveToward;
		isAggro = distance < aggroRange;

		if (isAggro) {
			moveToward= playerLocation - currentPosition ;
			Debug.Log("aggro");
				} else {
		    moveToward = Random.insideUnitSphere;
			Debug.Log ("Random mode");
				}

			// 4
			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0; 
			moveDirection.Normalize ();
			
			Vector3 target = moveDirection * moveSpeed + currentPosition;
			transform.position = Vector3.Lerp( currentPosition, target, Time.deltaTime );
			
			//Debug.Log("click from ["+moveToward.ToString()+"] yielded to target ["+target.ToString()+"]");
			//handle rotation
//			float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
//			transform.rotation = 
//				Quaternion.Slerp( transform.rotation, 
//				                 Quaternion.Euler( 0, 0, targetAngle ), 
//				                 turnSpeed * Time.deltaTime );				
	}
}
