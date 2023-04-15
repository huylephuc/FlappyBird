using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private const float TIME_ALIVE = 3;
    private float speed = 0.05f;
    private float time;
    [SerializeField] private BoxCollider2D pipeUp;
    [SerializeField] private BoxCollider2D pipeDown;

    private void OnEnable()
    {
        time = 0;
    }

    void Update()
    {
        if (GameManager.instance.GameEnd /*|| !GameManager.instance.IsStarted*/)
        {
            pipeUp.enabled = false;   
            pipeDown.enabled = false;   
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
