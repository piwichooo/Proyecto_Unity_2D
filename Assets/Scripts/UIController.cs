using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public static UIController instance;

	public Image heart1, heart2, heart3;

	public Sprite heartFull, heartEmpty, heartHalf;

	public Image fageScreen;
	public float fadeSpeed;
	private bool shouldFadeToBlack, shouldFadeFromBlack;

	public GameObject levelCompleteText;

	private void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () {
		FadeFromBlack ();
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldFadeToBlack) {
			fageScreen.color = new Color (fageScreen.color.r, fageScreen.color.b, Mathf.MoveTowards (fageScreen.color.a, 255, fadeSpeed * Time.deltaTime));
			if (fageScreen.color.a == 255) {
				shouldFadeToBlack = false;
			}
		}
		if (shouldFadeFromBlack) {
			fageScreen.color = new Color (fageScreen.color.r, fageScreen.color.b, Mathf.MoveTowards (fageScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
			if (fageScreen.color.a == 0f) {
				shouldFadeFromBlack = false;
			}
		}

	}


	public void UpdateHealthDisplay()
	{
		switch (PlayerHealtController.instance.currentHealth) {

		case 6:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartFull;

			break;

		case 5:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartHalf;

			break;
		case 4:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartEmpty;

			break;


		case 3:
			heart1.sprite = heartFull;
			heart2.sprite = heartHalf;
			heart3.sprite = heartEmpty;
			break;

		case 2:
			heart1.sprite = heartFull;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			break;
		case 1:
			heart1.sprite = heartHalf;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			break;

		case 0:
			heart1.sprite = heartEmpty;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			break;

		default:
			heart1.sprite = heartEmpty;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			break;
		}
	}

	public void FadeToBlack(){
		shouldFadeToBlack = true;
		shouldFadeFromBlack = false;
	}

	public void FadeFromBlack(){
		shouldFadeFromBlack = true;
		shouldFadeToBlack = false;
	}
}
