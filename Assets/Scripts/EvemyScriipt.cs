using UnityEngine;
using System.Collections;

//Feel free to sue me at hanokh.aloni@gmail.com for any naming complaints.
using System;


public class EvemyScriipt : MonoBehaviour
{
	public float moveSpeed;
	//public float turnSpeed;
	private Vector3 moveDirection;
	public bool facingRight = false;
	public float aggroRange;
	public bool isAggro;
	private DateTime lastChangeDirTime; // last time enemy changed right/left direction

	// messaging system
	public enum CMDMESSAGE { GO_HOME_MSG,NONE };	
	public static CMDMESSAGE message=CMDMESSAGE.NONE;
	
	//var target = PlayerUpdateLocation;
	// Use this for initialization
	void Start ()
	{
		lastChangeDirTime = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update ()
	{
			if (handleMessage ())
				return;
			Vector3 currentPosition = transform.position;
			var playerObject = GameObject.Find ("Player");
			Vector3 playerLocation = playerObject.transform.position;
			float distance = Vector3.Distance (currentPosition, playerLocation);
			isAggro = distance < (aggroRange * GUIUpdate.pitaCount);

			if (isAggro) { 
				moveDirection = playerLocation - currentPosition;
					//Debug.Log("aggro");
			} else {
				moveDirection += UnityEngine.Random.insideUnitSphere;//TODO need to do something nicer here :)
					//Debug.Log ("Random mode");
			}

			// 4
			moveDirection.z = 0; 
			moveDirection.Normalize ();
		
			Vector3 target = moveDirection * moveSpeed + currentPosition;
			
			
			bool shouldFlip = false;

			if ((moveDirection.x > 0) && (facingRight))
						shouldFlip = true;
			else if ((moveDirection.x < 0) && (!facingRight)) 
						shouldFlip = true;
			// else 
				//animation.Stop();//TODO1

		// camel should not change direction too many times in 1 second
		//if (DateTime.Now.Subtract(lastChangeDirTime).TotalMilliseconds > 1000) 	
		//{
		    if (shouldFlip)
				Flip();
			transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);
		}

		private bool handleMessage()
		{
			bool actionDone = true;
			switch(message)
			{
				case CMDMESSAGE.GO_HOME_MSG: 
					//Camera.main.ScreenToWorldPoint( Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane) );
					transform.position = new Vector3(-4,2,0);
					break;
				default:
					actionDone = false;
					break;
			}
			if (actionDone)
				message = CMDMESSAGE.NONE;
			return actionDone;
		}

		void Flip ()
		{
				facingRight = !facingRight;
		
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		
		}
}
