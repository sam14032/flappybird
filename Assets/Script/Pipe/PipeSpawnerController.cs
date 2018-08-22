using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerController : MonoBehaviour
{
	private GameController gameController;
	private TimedSpawner timedSpawner;

	private void Awake()
	{
		gameController = GameObject.FindWithTag(Tags.GameController)
			.GetComponent<GameController>();
		timedSpawner = GetComponent<TimedSpawner>();

		UpdateTimedSpawner();
	}

	private void OnEnable()
	{
		gameController.OnGameStartedChanged += UpdateTimedSpawner;
	}

	private void OnDisable()
	{
		gameController.OnGameStartedChanged -= UpdateTimedSpawner;
	}

	private void UpdateTimedSpawner()
	{
		timedSpawner.enabled = gameController.IsGameStarted;
	}
}

