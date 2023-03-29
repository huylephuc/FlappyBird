using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private GameObject getReady;

    /*void Start()
    {
        InvokeRepeating("SpawnPipe", 2f, 2f);
    }*/

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        getReady.SetActive(false);
        Player.PlayerGrav = 150;
        StartCoroutine(Spawn());
    }
    void SpawnPipe()
    {
        var position = new Vector3(pipePrefab.transform.position.x, Random.Range(-230, 600), 0);
        GameObject pipe = ObjectPool.instance.GetPooledObject();
        pipe.transform.position = position;
        pipe.transform.rotation = Quaternion.identity;
        pipe.SetActive(true);
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            SpawnPipe();
            yield return new WaitForSeconds(2);
        }
    }
}
