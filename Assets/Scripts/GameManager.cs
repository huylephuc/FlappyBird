using System;
using UnityEngine;

public enum GameState
{
    MainMenu,
    Market,
    StandBy,
    StartGame,
    EndGame
}

public enum GameTime
{
    Day,
    Night
}

public enum Color
{
    Yellow,
    Blue,
    Red
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameState state;
    public GameTime gameTime;
    public Color color;
    public static event Action<GameState> OnStateChange; //declare event
    public static event Action<GameTime> OnTimeChange;
    public static event Action<Color> OnUnitChanged;

    private bool isStarted;
    private bool gameStart;
    private bool gameEnd;
    private bool dayTime;
    private bool isYellow;
    private bool isBlue;
    private bool isRed;
    
    public bool IsStarted { get => isStarted; set => isStarted = value; }
    public bool GameStart { get => gameStart; set => gameStart = value; }
    public bool GameEnd { get => gameEnd; set => gameEnd = value; }
    public bool DayTime { get => dayTime; set => dayTime = value; }
    public bool IsYellow { get => isYellow; set => isYellow = value; }
    public bool IsBlue { get => isBlue; set => isBlue = value; }
    public bool IsRed { get => isRed; set => isRed = value; }

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
        ChangeColor(Color.Yellow);
        Application.targetFrameRate = 60;
        
    }

    private void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }

    #region Game State
    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.MainMenu:
                HandleMainMenu();
                break;
            case GameState.Market:
                HandleMarket();
                break;
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


    private void HandleMainMenu()
    {
        isStarted = false;
        gameStart = false;
        gameEnd = false;
    }
    private void HandleMarket()
    {
        isStarted = false;
    }
    private void HandleStandBy()
    {
        isStarted = true;
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
    #endregion

    #region Time
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
    #endregion

    #region Color
    public void ChangeColor(Color newColor)
    {
        color = newColor;
        switch (color)
        {
            case Color.Yellow:
                HandleYellow();
                break;
            case Color.Blue:
                HandleBlue();
                break;
            case Color.Red:
                HandleRed();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newColor), newColor, null);
        }
        OnUnitChanged?.Invoke(newColor);
    }

    private void HandleYellow()
    {
        isYellow = true;
        isBlue = false;
        isRed = false;
    }

    private void HandleBlue()
    {
        isYellow = false;
        isBlue = true;
        isRed = false;
    }

    private void HandleRed()
    {
        isYellow = false;
        isBlue = false;
        isRed = true;
    }
    #endregion
}