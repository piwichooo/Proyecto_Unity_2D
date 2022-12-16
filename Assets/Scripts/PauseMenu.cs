using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static PauseMenu instance;

	public GameObject pauseScreen;
	public bool isPaused;



	// Use this for initialization
	void Awake() {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Menu")) {
			PauseUnpause();
		}
	}
	public void PauseUnpause(){
		if (isPaused) {
			isPaused = false;
			pauseScreen.SetActive (false);
			Time.timeScale = 1f;
		} else {
			isPaused = true;
			pauseScreen.SetActive (true);
			Time.timeScale = 0f;
		}
	}
}
