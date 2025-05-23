﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedIncreasMilestoneStore;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;

	public float jumpForce;
	public float jumpTime;
	private float jumpTimeCounter;
	private bool stoppedJumping;
	private bool canDoubleJump;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	private Rigidbody2D myRigidbody;
	//private Collider2D myCollider;

	private Animator myAnimator;

	public GameManager theGameManager;

	public AudioSource jumpSound;
	public AudioSource deathSound;

	public IEnumerator run (){
		yield return new WaitForSeconds(1);
		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y);
	}

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		//myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreasMilestoneStore = speedIncreaseMilestone;
		}
	
	// Update is called once per frame
	void Update () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		if (transform.position.x > speedMilestoneCount)
		{
			speedMilestoneCount += speedIncreaseMilestone;
			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
			moveSpeed = moveSpeed * speedMultiplier;
		}

		StartCoroutine ("run");

		if (Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.UpArrow))
		{
			Debug.Log("1");
			if(grounded){

				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				stoppedJumping = false;
				jumpSound.Play ();
				}
			if (!grounded && canDoubleJump)
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				//jumpTimeCounter = jumpTime;
				stoppedJumping = false;
				canDoubleJump = false;
				jumpSound.Play ();
			}
		}
		if ((Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.UpArrow) && !stoppedJumping)) {
			if (jumpTimeCounter > 0){
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}

		}
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		if (grounded){
			jumpTimeCounter = jumpTime;
			canDoubleJump = true;
		}

		myAnimator.SetBool("Grounded", grounded);
	}
	void OnCollisionEnter2D (Collision2D other)
	{

		if (other.gameObject.tag == "killbox") 
		{
			theGameManager.RestartGame();
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreasMilestoneStore;
			deathSound.Play();
		}

	}
}


