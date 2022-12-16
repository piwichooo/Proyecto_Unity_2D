using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public static LevelManager instance;

	public float waitToRespawn;

	public string levelToLoad;

	private void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void RespawnPlayer()
	{
		StartCoroutine (RespawnCo());
	}

	IEnumerator RespawnCo()
	{
		PlaverController.instance.gameObject.SetActive(false);
		yield return new WaitForSeconds (waitToRespawn - (1f / UIController.instance.fadeSpeed ));

		UIController.instance.FadeToBlack ();
		yield return new WaitForSeconds ((1f / UIController.instance.fadeSpeed )+.2f);

		UIController.instance.FadeFromBlack();


		PlaverController.instance.gameObject.SetActive(true);

		PlaverController.instance.transform.position = CheckpointController.instance.spawnPoint;


		PlayerHealtController.instance.currentHealth = PlayerHealtController.instance.maxHealth;
		UIController.instance.UpdateHealthDisplay ();
	}
	public void EndLevel(){
		StartCoroutine(EndLevelCo());
	}
	public IEnumerator EndLevelCo(){
		PlaverController.instance.stopInput = true;

		CameraController.instance.stopFollow = true;

		UIController.instance.levelCompleteText.SetActive (true);

		yield return new WaitForSeconds (1.5f);

		UIController.instance.FadeToBlack ();

		yield return new WaitForSeconds ((1f / UIController.instance.fadeSpeed) + .25f);

		SceneManager.LoadScene (levelToLoad);
	}
}
