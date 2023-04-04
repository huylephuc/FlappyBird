using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private GameManager gameManager;
    private float speed = 2f;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        transform.position -= new Vector3(speed, 0);
        if (!Player.IsAlive)
        {
            speed = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Wall"))
            gameObject.SetActive(false);
    }
}
