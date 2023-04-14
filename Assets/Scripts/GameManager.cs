using System;
using UnityEngine;

public enum GameState
{
    StandBy,
    StartGame,
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
    public bool GameStart { get => gameStart; set => gameStart = value; }
    public bool GameEnd { get => gameEnd; set => gameEnd = value; }
    public bool DayTime { get => dayTime; set => dayTime = value; }

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
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        UpdateGameState(GameState.StandBy);
        ChangeTime(GameTime.Day);
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
        }
        OnTimeChange?.Invoke(newTime);
    }

    private void HandleDayTime()
    {
        dayTime = false;
    }
    private void HandleNightTime()
    {
        dayTime = true;
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

    private void HandleEndGame()
    {
        gameEnd = true;
    }
}