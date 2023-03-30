using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private GameObject getReady;
    [SerializeField] private Text score;

    private void Start()
    {
        InvokeRepeating("SpawnPipe", 2f, 1.75f);
        score.enabled = false;
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
        getReady.SetActive(false);
        Player.PlayerGrav = 35;
        score.enabled = true;
    }
    void SpawnPipe()
    {
        var position = new Vector3(pipePrefab.transform.position.x, Random.Range(-35, 90), 0);
        GameObject pipe = ObjectPool.instance.GetPooledObject();
        pipe.transform.position = position;
        pipe.transform.rotation = Quaternion.identity;
        pipe.SetActive(true);
    }
}
