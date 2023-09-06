using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    private float spawnTime = 0;
    private const float timeBetweenSpawn = 1.75f;

    void Update()
    {
        if (!GameManager.instance.GameEnd && GameManager.instance.GameStart)
        {
            if (spawnTime >= timeBetweenSpawn)
            {
                Spawn();
                spawnTime = 0;
            }
            spawnTime += Time.deltaTime;
        }
    }

    public void Spawn()
    {
        Vector3 position = new Vector3(pipePrefab.transform.position.x, Random.Range(-1, 3), 0);
        GameObject pipe = ObjectPool.instance.GetPooledObject();
        pipe.transform.position = position;
        pipe.SetActive(true);
    }
}
