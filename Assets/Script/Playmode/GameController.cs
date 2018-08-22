using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void GameControllerEventHandler();

public class GameController : MonoBehaviour
{
    [Header("Inputs")] [SerializeField] private KeyCode startKey = KeyCode.Space;

    private MainController mainController;
    private PipePassedEventChannel pipePassedEventChannel;
    private BirdDeathEventChannel birdDeathEventChannel;
    
    private int score;
    private bool isGameStarted;
    private bool isGameOver;

    public event GameControllerEventHandler OnScoreChanged;
    public event GameControllerEventHandler OnGameStartedChanged;
    public event GameControllerEventHandler OnGameOverChanged;

    private Canvas mainMenuCanvas;
    private Canvas headUpDisplayCanvas;
    private Canvas deathScreenCanvas;

    public int Score
    {
        get { return score; }
        set
        {
            if (score != value)
            {
                score = value;
                NotifyScoreChanged();
            }
        }
    }
    
    public bool IsGameStarted
    {
        get { return isGameStarted; }
        set
        {
            if (isGameStarted != value)
            {
                isGameStarted = value;
                NotifyGameStartedChanged();
            }
        }
    }

    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        {
            if (isGameOver != value)
            {
                isGameOver = value;
                NotifyGameOverChanged();
            }
        }
    }

    private void Awake()
    {
        mainController = GameObject.Find("MainController").GetComponent<MainController>();
        pipePassedEventChannel = GetComponent<PipePassedEventChannel>();
        birdDeathEventChannel = GetComponent<BirdDeathEventChannel>();
        Canvas[] canvas = GameObject.Find("Display").GetComponentsInChildren<Canvas>();
        mainMenuCanvas = canvas[1];
        headUpDisplayCanvas = canvas[2];
        deathScreenCanvas = canvas[3];
    }

    private void OnEnable()
    {
        pipePassedEventChannel.OnEventPublished += IncrementScore;
        birdDeathEventChannel.OnEventPublished += StopGame;
    }

    private void Update()
    {
        if (!IsGameStarted)
        {
            ShowStartCanvas();
            if (Input.GetKeyDown(startKey))
            {
                ShowGameCanvas();
                StartGame();
            }
        }
        else if (IsGameOver)
        {
            ShowDeathCanvas();
            if (Input.GetKeyDown(startKey))
            {
                ShowGameCanvas();
                RestartGame();
            }
        }
    }

    private void OnDisable()
    {
        pipePassedEventChannel.OnEventPublished -= IncrementScore;
    }
    
    private void IncrementScore()
    {
        Score++;
    }

    private void StartGame()
    {
        IsGameStarted = true;
    }

    private void StopGame()
    {
        IsGameOver = true;
    }

    private void RestartGame()
    {
        mainController.RestartGame();
    }
    
    private void NotifyScoreChanged()
    {
        if (OnScoreChanged != null) OnScoreChanged();
    }
    
    private void NotifyGameStartedChanged()
    {
        if (OnGameStartedChanged != null) OnGameStartedChanged();
    }

    private void NotifyGameOverChanged()
    {
        if (OnGameOverChanged != null) OnGameOverChanged();
    }

    private void DisableCanvas(Canvas canvas)
    {
        canvas.enabled = false;
    }

    private void EnableCanvas(Canvas canvas)
    {
        canvas.enabled = true;
    }

    private void ShowStartCanvas()
    {
        EnableCanvas(mainMenuCanvas);
        DisableCanvas(headUpDisplayCanvas);
        DisableCanvas(deathScreenCanvas);
    }

    private void ShowGameCanvas()
    {
        DisableCanvas(mainMenuCanvas);
        DisableCanvas(deathScreenCanvas);
        EnableCanvas(headUpDisplayCanvas);  
    }

    private void ShowDeathCanvas()
    {
        EnableCanvas(deathScreenCanvas);
        EnableCanvas(headUpDisplayCanvas); 
        DisableCanvas(mainMenuCanvas);
    }
}


