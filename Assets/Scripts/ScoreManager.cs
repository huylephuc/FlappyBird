using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour , IObserver
{
    public static ScoreManager instance { get; private set; }
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreBoardText;
    [SerializeField] private Text highScoreBoardText;
    [SerializeField] private Canvas scoreCanvas;
    [SerializeField] private SpriteRenderer newHS;

    private int score;
    private int highScore = 0;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        GameManager.OnStateChange += DisplayScoreOnStateChange;
    }

    private void OnDestroy()
    {
        GameManager.OnStateChange -= DisplayScoreOnStateChange;
    }

    private void Start()
    {
        InitScore();
        DisplayScore();
    }

    private void InitScore()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("Highscore");
    }

    private void DisplayScoreOnStateChange(GameState state)
    {
        scoreCanvas.gameObject.SetActive(state == GameState.StartGame);
    }

    public void AddScore()
    {
        score++;
        UpdateHighScore();
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = score.ToString();
        scoreBoardText.text = score.ToString();
        highScoreBoardText.text = highScore.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
            newHS.enabled = true;
        }
    }

    public void OnNotify()
    {
        
    }
}
