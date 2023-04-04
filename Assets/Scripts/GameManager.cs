using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private GameObject getReady;

    [Header("Scoreboard")]
    [SerializeField] private Canvas scoreBoard;
    [SerializeField] private Text score;
    [SerializeField] private Text scoreBoardText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private SpriteRenderer newHS;
    [SerializeField] private SpriteRenderer copper;
    [SerializeField] private SpriteRenderer silver;
    [SerializeField] private SpriteRenderer gold;

    private bool isStarted = false;
    private bool spawned = false;

    private void OnEnable()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        getReady.SetActive(true);
        score.enabled = false;
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    void Update()
    {
        if (!isStarted)
        {
            Player.PlayerGrav = 0;
        }
        if (isStarted && !spawned)
        {
            spawned = true;
            InvokeRepeating("SpawnPipe", 2f, 1.5f);
        }
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
        score.text = Player.Score.ToString();
        if (!Player.IsAlive)
        {
            GameOver();
        }
    }

    void StartGame()
    {
        isStarted = true;
        getReady.SetActive(false);
        Player.PlayerGrav = 35;
        score.enabled = true;
    }
    void SpawnPipe()
    {
        Vector3 position = new Vector3(pipePrefab.transform.position.x, Random.Range(-35, 90), 0);
        GameObject pipe = ObjectPool.instance.GetPooledObject();
        pipe.transform.position = position;
        pipe.transform.rotation = Quaternion.identity;
        pipe.SetActive(true);
    }

    public void GameOver()
    {
        isStarted = false;
        Time.timeScale = 0;
        scoreBoard.gameObject.SetActive(true);
        score.enabled = false;
        scoreBoardText.text = Player.Score.ToString();
        if (Player.Score < PlayerPrefs.GetInt("HighScore", 0) / 2)
        {
            copper.enabled = true;
        }
        if (Player.Score >= PlayerPrefs.GetInt("HighScore", 0) / 2 || Player.Score == PlayerPrefs.GetInt("HighScore", 0))
        {
            silver.enabled = true;
        }
        if (Player.Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Player.Score);
            highScoreText.text = Player.Score.ToString();
            newHS.enabled = true;
            gold.enabled = true;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}
