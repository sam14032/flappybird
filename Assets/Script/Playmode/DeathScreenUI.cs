using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenUI : MonoBehaviour
{
	private GameController gameController;

	private void Awake()
	{
		gameController = GameObject.FindWithTag(Tags.GameController)
			.GetComponent<GameController>();
        
		gameController.OnGameOverChanged += UpdateUI;

		UpdateUI();
	}

	private void OnDestroy()
	{
		gameController.OnGameOverChanged -= UpdateUI;
	}

	private void UpdateUI()
	{
		gameObject.SetActive(gameController.IsGameOver);
	}
}

