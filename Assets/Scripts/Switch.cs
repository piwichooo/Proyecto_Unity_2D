using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public GameObject objecToSwitch;

	private SpriteRenderer theSR;
	public Sprite downSprite;

	private bool hasSwitched;

	public bool desactivateOnSwitch;


	// Use this for initialization
	void Start () {
		theSR = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player" && !hasSwitched) {
			if (desactivateOnSwitch) {
				objecToSwitch.SetActive (false);
			} else {
				objecToSwitch.SetActive (true);
			}


			theSR.sprite = downSprite;
			hasSwitched = true;
		}




	}
}
