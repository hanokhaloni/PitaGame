using UnityEngine;
using System.Collections;



public class PlayerUpdateLocation : MonoBehaviour {
	public float moveSpeed;
	public float turnSpeed;
	private Vector3 moveDirection;
	public GUIText pitaCounterText;

	private int pitaCounter;


	private Animator animator;
	//private SpriteRenderer spriteRenderer; 

	public bool facingRight = false;

	// Use this for initialization
	void Start () {
		//spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		//animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;
		// 2

		if (Input.GetButton ("Fire1")) {
			//animation.Play();//TODO1
			// 3
			Vector3 moveToward = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			// 4
			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0; 
			moveDirection.Normalize ();

			Vector3 target = moveDirection * moveSpeed + currentPosition;
			transform.position = Vector3.Lerp( currentPosition, target, Time.deltaTime );

			//Debug.Log("click from ["+moveToward.ToString()+"] yielded to target ["+target.ToString()+"]");
//			//handle rotation
//			float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
//			transform.rotation = 
//				Quaternion.Slerp( transform.rotation, 
//				                 Quaternion.Euler( 0, 0, targetAngle ), 
//				                 turnSpeed * Time.deltaTime );
			if ((moveDirection.x > 0) && (facingRight)) {
				Flip();
				//spriteRenderer.transform.TransformDirection(new Vector3(-1,0,0));
			}
			if ((moveDirection.x < 0) && (!facingRight)) {
				Flip();
			}
			else {
				//animation.Stop();//TODO1
			}



		}					
	}

	void Flip() {
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

		}

	void OnCollisionEnter2D(Collision2D coll){
		Debug.Log ("Collision detected");
//		if(coll.gameObject.tag=="enemy")
//		{
//			GameObject.Destroy("player");
//		}
	}

	void setPitaCounter(int newPitaCounter) {
		pitaCounter = newPitaCounter;

		pitaCounterText.text = pitaCounter.ToString ();

	}

	public void addPitaCounter() {
		if (pitaCounter < 10)
			setPitaCounter (pitaCounter ++);
	}

	public void decPitaCounter() {
		if (pitaCounter > 0)
			setPitaCounter (pitaCounter --);
	}

}
