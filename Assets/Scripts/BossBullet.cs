﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (-speed * transform.localScale.x * Time.deltaTime, 0f, 0f);
	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			PlayerHealtController.instance.DealDamage ();
		}
		Destroy (gameObject);
	}

}
