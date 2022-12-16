using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankMine : MonoBehaviour {
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Explode ();

			PlayerHealtController.instance.DealDamage ();
		}
	}

	public void Explode(){
		Destroy (gameObject);
		Instantiate (explosion, transform.position, transform.rotation);
	}
}
