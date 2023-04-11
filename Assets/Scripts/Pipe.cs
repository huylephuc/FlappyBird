using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private const float TIME_ALIVE = 3;
    private float speed = 0.05f;
    private float time;

    private void OnEnable()
    {
        time = 0;
    }

    void Update()
    {
        if (GameManager.instance.GameEnd)
        {
            return;
        }
        transform.position -= new Vector3(speed, 0);
        if (time >= TIME_ALIVE)
        {
            gameObject.SetActive(false);
        }
        time += Time.deltaTime;
    }

    
}
