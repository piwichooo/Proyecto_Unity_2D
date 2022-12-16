﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTankController : MonoBehaviour {
	public enum bossStates { shooting, hurt, moving, ended };
	public bossStates currentStates;


	public Transform theBoss;
	public Animator anim;

	[Header("Movement")]
	public float moveSpeed;


	public Transform leftPoint, rigthPoint;
	private bool moveRigth;
	public GameObject mine;
	public Transform minePoint;
	public float timeBetweenMines;
	private float mineCounter;

	[Header("Shooting")]
	public GameObject bullet;
	public Transform firePoint;
	public float timeBetweenShots;
	private float shotCounter;

	[Header("Hurt")]
	public float hurtTime;
	private float hurtCounter;

	public GameObject hitBox;

	[Header("Health")]
	public int health = 5;
	public GameObject explosion, winPlatform;

	private bool isDefeated;
	public float shotSpeedUp, mineSpeedUp;


	// Use this for initialization
	void Start () {
		currentStates = bossStates.shooting;

	}
	
	// Update is called once per frame
	void Update () {
		switch (currentStates) {
		case bossStates.shooting:

			shotCounter -= Time.deltaTime;

			if (shotCounter <= 0) {
				shotCounter = timeBetweenShots;

				var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
				newBullet.transform.localScale = theBoss.localScale;
			}
			break;
		case bossStates.hurt:
			if (hurtCounter > 0) {
				hurtCounter -= Time.deltaTime;

				if (hurtCounter <= 0) {
					currentStates = bossStates.moving;

					mineCounter = 0;

					if(isDefeated){
						theBoss.gameObject.SetActive (false);
						Instantiate (explosion, theBoss.position, theBoss.rotation);


						winPlatform.SetActive (true);

						AudioManager.instance.StopBossMusic ();

						currentStates = bossStates.ended;
					}
				}

			}
			break;

		case bossStates.moving:

			if (moveRigth) {
				theBoss.position += new Vector3 (moveSpeed * Time.deltaTime, 0f, 0f);

				if (theBoss.position.x > rigthPoint.position.x) {

					theBoss.localScale = Vector3.one;

					moveRigth = false;

					EndMovement ();
				}
			} else {
				theBoss.position -= new Vector3 (moveSpeed * Time.deltaTime, 0f, 0f);

				if (theBoss.position.x < leftPoint.position.x) {
					theBoss.localScale = new Vector3 (-1f, 1f, 1f);

					moveRigth = true;

					EndMovement ();
				}
			}


			mineCounter -= Time.deltaTime;
			if(mineCounter <= 0){
				mineCounter = timeBetweenMines;

				Instantiate (mine, minePoint.position, minePoint.rotation);
			}

			break;
		}
	}


	public void TakeHit()
	{
		currentStates = bossStates.hurt;
		hurtCounter = hurtTime;


		anim.SetTrigger ("Hit");


		BossTankMine[] mines = FindObjectsOfType<BossTankMine>();

		if(mines.Length > 0){
			foreach (BossTankMine foundMine in mines) {
				foundMine.Explode ();
			}
		}
		health--;

		if (health <= 0) {
			isDefeated = true;
		} else {
			timeBetweenShots /= shotSpeedUp;
			timeBetweenMines /= mineSpeedUp;
		}
	}

	private void EndMovement(){
		currentStates = bossStates.shooting;

		shotCounter = 0f;

		anim.SetTrigger ("StopMoving");

		hitBox.SetActive (true);

	}
}
