using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Control : MonoBehaviour 
{
	public Vector2 move = Vector2.zero;
	private Rigidbody2D playerRb;
	public bool isFacingRight = true;
	public bool isJumping = false;
	public bool isFalling = false;
	public bool isGrounded = false;
	public float moveSpeed = 5;
	public float jumpForce = 300;

	private bool jump = false;
	private SpriteRenderer spriteRenderer;
	private Animator animator;





	void Awake () 
	{
		playerRb = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		animator = GetComponent<Animator> ();
	}

	void Update () 
//Player 1 Movement 
	{
		animator.SetBool ("isGrounded", isGrounded);
		animator.SetFloat ("velocityX", Mathf.Abs (playerRb.velocity.x) / moveSpeed);
		animator.SetBool ("isJumping", isJumping);
		animator.SetBool ("isFalling", isFalling);

		if (Input.GetButtonDown("P1Jump") && isGrounded)
			jump = true;

		float P1Horizontal = Input.GetAxis("P1Horizontal");
		movementP1 (P1Horizontal);	
		if (jump) 
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
//isJumping--------------------------------------------------------
		if (playerRb.velocity.y > 0.1 && !isGrounded)
		{
			isJumping = true;
		}
		else
		{
			isJumping = false;
		}
//isFalling--------------------------------------------------------
		if (playerRb.velocity.y < -0.1)
		{
			isFalling = true;
		}
		else
		{
			isFalling = false;
		}
		if (isFalling == true) 
		{
			playerRb.gravityScale = 10f*Time.deltaTime*8+Time.deltaTime;
		} else 
		{
			playerRb.gravityScale = 1f;
		}
			

//Flip--------------------------------------------------------
		if (P1Horizontal < 0f) 
		{
			isFacingRight = false;
			transform.localScale = new Vector3 (-1, 1, 1);
		} else if (P1Horizontal > 0f) 
		{
			isFacingRight = true;
			transform.localScale = new Vector3 (1, 1, 1);
		}
	}
//????tbh--------------------------------------------------------
	private void movementP1(float P1Horizontal)
	{
		playerRb.velocity = new Vector2(P1Horizontal * moveSpeed, playerRb.velocity.y);
	}
		

//isGrounded--------------------------------------------------------

	private void OnTriggerEnter2D(Collider2D col)
	{
		isGrounded = true;
	}
	private void OnTriggerStay2D(Collider2D col)
	{
		isGrounded = true;
	}
	private void OnTriggerExit2D(Collider2D col)
	{
		isGrounded = false;
	}
}



/*
	public float moveSpeed = 6;
	public float jumpForce = 6;

	public bool isFalling;
	public bool isFacingRight;
	public bool cantConfigure;
	public KeyCode Left;
	public KeyCode Right;
	public KeyCode Jump;
	public KeyCode Attack;

	private bool attack;
	private SpriteRenderer spriteRenderer;
	private Animator animator;

	// Use this for initialization
	void Awake () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		animator = GetComponent<Animator> ();
	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		attack = Input.GetButtonDown ("attack1");
		move.x = Input.GetAxis ("Horizontal1");

		if (Input.GetButtonDown ("Jump1") && grounded) 
		{
			velocity.y = jumpForce;
		} else if (Input.GetButtonUp ("Jump1")) 
		{
			if (velocity.y > 0) 
			{
				velocity.y = velocity.y * 0.5f;
			}
		}

		// Is Facing Right
		{

			if (move.x < 0f) {
				isFacingRight = false;
				transform.localScale = new Vector3 (-1, 1, 1);
			} else if (move.x > 0.01f) {
				isFacingRight = true;
				transform.localScale = new Vector3 (1, 1, 1);
			}
		}
			
		// Is Falling
		{

			if (move.y < 0f)
			{
				isFalling = false;
			}
			else if (move.y > 0.01f)
			{
				isFalling = true;
			}
		

			animator.SetBool ("grounded", grounded);
			animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / moveSpeed);
			animator.SetBool ("attack", attack);
			animator.SetBool ("isFalling", isFalling);

			targetVelocity = move * moveSpeed;
*/