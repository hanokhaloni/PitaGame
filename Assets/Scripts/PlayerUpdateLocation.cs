using UnityEngine;
using System.Collections;
using System;


public class PlayerUpdateLocation : MonoBehaviour {
	public float moveSpeed;
	public float turnSpeed;
	private Vector3 moveDirection;
	private DateTime lastPitaTaken;

	public int pitaCounter;
	public int maxPitaCanBeHeld = 50;
	public int mSecBetweenPitaPickups = 500;

	//private Animator animator;
	//private SpriteRenderer spriteRenderer; 

	public bool facingRight = false;

	private AudioSource audioPitaCollected;
	private AudioSource audioPitaStolen;

	// Use this for initialization
	void Start () {
		//spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		//animator = this.GetComponent<Animator>();
		lastPitaTaken = DateTime.Now;
		AudioSource[] sounds = GetComponents<AudioSource> ();
		audioPitaCollected = sounds[0];
		audioPitaStolen = sounds[1];
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;
		// 2

		if (Input.GetButton ("Fire1")) {
			//animation.Play();//TODO1
			Vector3 moveToward = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0; 
			moveDirection.Normalize ();
			Vector3 target = moveDirection * moveSpeed + currentPosition;




			transform.position = Vector3.Lerp( currentPosition, target, Time.deltaTime );


			if ((moveDirection.x > 0) && (!facingRight)) {
				Flip();
				//spriteRenderer.transform.TransformDirection(new Vector3(-1,0,0));
			}
			if ((moveDirection.x < 0) && (facingRight)) {
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

	// camel touches pita boy
	void OnCollisionEnter2D(Collision2D coll){
		decPitaCounter ();
		EvemyScriipt.message = EvemyScriipt.CMDMESSAGE.GO_HOME_MSG;
		//TODO play random collison sound
	}



	public void addPitaCounter() {
		double timeSinceLastTake = DateTime.Now.Subtract (lastPitaTaken).TotalMilliseconds;
		if (pitaCounter < maxPitaCanBeHeld && timeSinceLastTake > mSecBetweenPitaPickups) {
						pitaCounter++;
						GUIUpdate.pitaCount = pitaCounter;
						lastPitaTaken = DateTime.Now;
						audioPitaCollected.Play();
				}
	}

	public void decPitaCounter() {
		if (pitaCounter > 0) {
						pitaCounter--;
						GUIUpdate.pitaCount = pitaCounter;
						audioPitaStolen.Play();
				}

	}

	public void depositAllPitas()
	{
		pitaCounter = 0;
		GUIUpdate.pitaCount = pitaCounter;
		
	}

}
