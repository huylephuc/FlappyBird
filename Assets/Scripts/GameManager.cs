using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private GameObject getReady;
    [SerializeField] private Text score;
    [SerializeField] private Canvas scoreBoard;
    [SerializeField] private Text scoreBoardText;
    //private bool isStarted;

    private void Start()
    {
        InvokeRepeating("SpawnPipe", 2f, 1.75f);
        score.enabled = false;
        scoreBoard.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
        score.text = Player.Score.ToString();
    }

    void StartGame()
    {
        //isStarted = true;
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
        Time.timeScale = 0;
        scoreBoard.gameObject.SetActive(true);
        score.enabled = false;
        scoreBoardText.text = Player.Score.ToString();
        ObjectPool.instance.GetPooledObject().SetActive(false);
    }
}
