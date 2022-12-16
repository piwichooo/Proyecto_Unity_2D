using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaverController : MonoBehaviour {
	public static PlaverController instance;

	[Header("Movimiento")]

	public float moveSpeed;

	[Header("Salto")]
	private bool canDoubleJump;
	public float jumpForce;
	public float bounceForce;

	[Header("Componente")]
		
	public Rigidbody2D theRB;

	[Header("Animator")]
	public Animator anim;
	private SpriteRenderer theSR;



	[Header("Grounded")]
	private bool isGrounded;
	public Transform groundChekpoint;
	public LayerMask whatIsGround;


	public float knockBackLength, knockBackForce;
	private float knockBackCounter;

	public bool stopInput;



	private void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		theSR = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//movimiento
		if (!PauseMenu.instance.isPaused && !stopInput){
			if (knockBackCounter <= 0) {
				theRB.velocity = new Vector2 (moveSpeed * Input.GetAxis ("Horizontal"), theRB.velocity.y);

				isGrounded = Physics2D.OverlapCircle (groundChekpoint.position, .2f, whatIsGround);

				//salto

				if (isGrounded) {
					canDoubleJump = true;
				}

				if (Input.GetButtonDown ("Jump")) {
					if (isGrounded) {
						theRB.velocity = new Vector2 (theRB.velocity.x, jumpForce);
						AudioManager.instance.PlaySFX (10);
					} else {
						if (canDoubleJump) {
							theRB.velocity = new Vector2 (theRB.velocity.x, jumpForce);
							AudioManager.instance.PlaySFX (10);
							canDoubleJump = false;
						}
					}

				}

				if (theRB.velocity.x < 0) {
					theSR.flipX = true;

				} else if (theRB.velocity.x > 0) {
					theSR.flipX = false;
				}
			} else {
				knockBackCounter -= Time.deltaTime;
				if (!theSR.flipX) {
					theRB.velocity = new Vector2 (-knockBackForce, theRB.velocity.y);
				} else {
					theRB.velocity = new Vector2 (knockBackForce, theRB.velocity.y);
				}	
			}
		}


		//animaciones
		anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
		anim.SetBool ("isGrounded", isGrounded);
	}
	public void Knockback()
	{
		knockBackCounter = knockBackLength;
		theRB.velocity = new Vector2 (0f, knockBackForce);
	}

	public void Bounce(){
		theRB.velocity = new Vector2 (theRB.velocity.x, bounceForce);
	}
}
