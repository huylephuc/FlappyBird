using System;
using UnityEngine;

public enum GameState
{
    StandBy,
    StartGame,
    PauseGame,
    EndGame
}

public enum GameTime
{
    Day,
    Night
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameState state;
    public GameTime gameTime;
    public static event Action<GameState> OnStateChange; //declare event
    public static event Action<GameTime> OnTimeChange;

    private bool gameStart;
    private bool gameEnd;
    private bool dayTime;
    private bool paused;
    public bool GameStart { get => gameStart; set => gameStart = value; }
    public bool GameEnd { get => gameEnd; set => gameEnd = value; }
    public bool DayTime { get => dayTime; set => dayTime = value; }
    public bool Paused { get => paused; set => paused = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
        ChangeTime(GameTime.Day);
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        UpdateGameState(GameState.StandBy);
    }

    public void ChangeTime(GameTime newTime)
    {
        gameTime = newTime;
        switch (newTime)
        {
            case GameTime.Day:
                HandleDayTime();
                break;
            case GameTime.Night:
                HandleNightTime();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newTime), newTime, null);
        }
        OnTimeChange?.Invoke(newTime);
    }

    private void HandleDayTime()
    {
        dayTime = true;
    }
    private void HandleNightTime()
    {
        dayTime = false;
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.StandBy:
                HandleStandBy();
                break;
            case GameState.StartGame:
                HandleStartGame();
                break;
            case GameState.PauseGame:
                HandlePauseGame();
                break;
            case GameState.EndGame:
                HandleEndGame();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), newState, null);
        }

        OnStateChange?.Invoke(newState);
    }

    private void HandleStandBy()
    {
        gameStart = false;
        gameEnd = false;
    }

    private void HandleStartGame()
    {
        gameStart = true;
    }

    private void HandlePauseGame()
    {
        paused = true;
    }
    private void HandleEndGame()
    {
        gameEnd = true;
    }
}