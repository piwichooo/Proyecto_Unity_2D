using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtController : MonoBehaviour {
	public static PlayerHealtController instance;
	public int currentHealth, maxHealth;

	public float invincibleLength;
	private float invincibleCounter;

	private SpriteRenderer theSR;

	public GameObject deathEffect;

	//public GameObject deathEffect;
	private void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;

		theSR = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (invincibleCounter > 0) {
			invincibleCounter -= Time.deltaTime;



			if (invincibleCounter <= 0) {
				theSR.color = new Color (theSR.color.r, theSR.color.g, theSR.color.b, 1f);
			}
		}
	}



	public void DealDamage()
	{

		if (invincibleCounter <= 0) {
			currentHealth--;

			PlaverController.instance.anim.SetTrigger("Hurt");

			AudioManager.instance.PlaySFX (9);
			if (currentHealth <= 0) {
				currentHealth = 0;
				Instantiate (deathEffect, PlaverController.instance.transform.position, PlaverController.instance.transform.rotation);
				AudioManager.instance.PlaySFX (8);
				//Instantiate(deathEffect, PlaverController.instance.transform.position, PlaverController.instance.transform.rotation);

				LevelManager.instance.RespawnPlayer();
			} else {
				invincibleCounter = invincibleLength;
				theSR.color = new Color (theSR.color.r, theSR.color.g, theSR.color.b, .5f);

				PlaverController.instance.Knockback();
			}
		}



		UIController.instance.UpdateHealthDisplay();

	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Platform") {
			transform.parent = other.transform;
		}

	}


	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "Platform") {
			transform.parent = null;
		}

	}
}
