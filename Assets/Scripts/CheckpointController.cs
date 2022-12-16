using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckpointController : MonoBehaviour {
	public static CheckpointController instance;

	public Checkpoint[] checkpoints;

	public Vector3 spawnPoint;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	private void Start() {
		checkpoints = FindObjectsOfType<Checkpoint>();

		spawnPoint = PlaverController.instance.transform.position;
	}

	public void DeactivateCheckpoints()
	{
		for (int i = 0; i < checkpoints.Length; i++) {
			checkpoints[i].ResetCheckpoint();
		}
	}

	public void SetSpawnPoint(Vector3 newSpawnPoint)
	{
		spawnPoint = newSpawnPoint;
	}
}
