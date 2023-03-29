using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] private GameObject pipePrefab;
    private List<GameObject> pool;
    private int amountToPool = 5;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject tmp = Instantiate(pipePrefab);
            tmp.SetActive(false);
            pool.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0;i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy) return pool[i];
        }
        return null;
    }
}
