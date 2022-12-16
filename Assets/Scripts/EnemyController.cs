using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float moveSpeed;

	public Transform leftPoint, rightPoint;

	private bool movingRigth;

	private Rigidbody2D theRB;


	public SpriteRenderer theSR;

	//private Animator anim;


	public float moveTime, waitTime;
	//private float moveCount, waitCount;
	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D> ();
		//anim = GetComponent<Animator>();

		leftPoint.parent = null;
		rightPoint.parent = null;

		//movingRigth = true;

		//moveCount = moveTime;
	}
	
	// Update is called once per frame
	void Update () {


		//if (moveCount > 0) {
			//moveCount -= Time.deltaTime;
			if (movingRigth) {
				theRB.velocity = new Vector2 (moveSpeed, theRB.velocity.y);

				theSR.flipX = true;

				if (transform.position.x > rightPoint.position.x) {
					movingRigth = false;
				}
			} else {
				theRB.velocity = new Vector2 (-moveSpeed, theRB.velocity.y);
				theSR.flipX = false;


				if (transform.position.x < leftPoint.position.x) {
					movingRigth = true;
				}


			//if (moveCount <= 0) {
				//waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
			//}



			//anim.SetBool ("isMoving", true);

		//} else if (waitCount > 0) {
			//waitCount -= Time.deltaTime;
			//theRB.velocity = new Vector2 (0f, theRB.velocity.y);

			//if (waitCount <= 0) {
				//moveCount = Random.Range(moveTime * .75f, waitTime * 1.25f);
			//}
			//anim.SetBool ("isMoving", false);


		}


	}
}
