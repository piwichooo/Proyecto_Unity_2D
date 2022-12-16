using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTankHitbox : MonoBehaviour {
	public BossTankController bossCont;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player" && PlaverController.instance.transform.position.y > transform.position.y){
			bossCont.TakeHit ();

			PlaverController.instance.Bounce ();

			gameObject.SetActive (false);
		}
	}
}
