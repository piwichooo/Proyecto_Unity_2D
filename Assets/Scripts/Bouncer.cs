using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour {
	private Animator anim;
	public float bounceForce = 5f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			PlaverController.instance.theRB.velocity = new Vector2 (PlaverController.instance.theRB.velocity.x, bounceForce);
			anim.SetTrigger("Bouncer");
		}
	}
}
