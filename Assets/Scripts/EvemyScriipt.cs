using UnityEngine;
using System.Collections;

//Feel free to sue me at hanokh.aloni@gmail.com for any naming complaints.
public class EvemyScriipt : MonoBehaviour
{
		public float moveSpeed;
		//public float turnSpeed;
		private Vector3 moveDirection;
		public bool facingRight = false;
		public float aggroRange;
		public bool isAggro;

		//var target = PlayerUpdateLocation;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				Vector3 currentPosition = transform.position;
				// 2
				// 3
				var playerObject = GameObject.Find ("Player");
				Vector3 playerLocation = playerObject.transform.position;
				float distance = Vector3.Distance (currentPosition, playerLocation);
				isAggro = distance < (aggroRange * GUIUpdate.pitaCount);

				if (isAggro) { 
					moveDirection = playerLocation - currentPosition;
						//Debug.Log("aggro");
				} else {
					moveDirection += Random.insideUnitSphere;//TODO need to do something nicer here :)
						//Debug.Log ("Random mode");
				}

				// 4
				moveDirection.z = 0; 
				moveDirection.Normalize ();
			
				Vector3 target = moveDirection * moveSpeed + currentPosition;
				transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);
			
				//Debug.Log("click from ["+moveToward.ToString()+"] yielded to target ["+target.ToString()+"]");
				//handle rotation
//			float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
//			transform.rotation = 
//				Quaternion.Slerp( transform.rotation, 
//				                 Quaternion.Euler( 0, 0, targetAngle ), 
//				                 turnSpeed * Time.deltaTime );

				if ((moveDirection.x > 0) && (facingRight)) {
						Flip ();
						//spriteRenderer.transform.TransformDirection(new Vector3(-1,0,0));
				} else if ((moveDirection.x < 0) && (!facingRight)) {
						Flip ();
				} else {
						//animation.Stop();//TODO1
				}
		}

		void Flip ()
		{
				facingRight = !facingRight;
		
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		
		}
}
