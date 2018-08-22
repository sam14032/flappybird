using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreUI : MonoBehaviour
{
	private const string Format = "{0:00}";

	private GameController gameController;
	private Text text;

	private void Awake()
	{
		gameController = GameObject.FindWithTag(Tags.GameController).
			GetComponent<GameController>();
		text = GetComponent<Text>();
        
		UpdateUI();
	}

	private void OnEnable()
	{
		gameController.OnScoreChanged += UpdateUI;
	}

	private void OnDisable()
	{
		gameController.OnScoreChanged -= UpdateUI;
	}

	private void UpdateUI()
	{
		text.text = String.Format(Format, gameController.Score);
	}
}


