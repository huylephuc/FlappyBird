using System;
using UnityEngine;

public enum GameState
{
    StandBy,
    StartGame,
    EndGame
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameState state;
    public static event Action<GameState> OnStateChange; //declare event

    private bool gameStart;
    private bool gameEnd;
    public bool GameStart { get => gameStart; set => gameStart = value; }
    public bool GameEnd { get => gameEnd; set => gameEnd = value; }

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 90;
    }

    void Start()
    {
        UpdateGameState(GameState.StandBy);
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