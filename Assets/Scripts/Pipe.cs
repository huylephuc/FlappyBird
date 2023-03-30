using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float speed = 0.25f;

    void Update()
    {
        transform.position -= new Vector3(speed, 0);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Wall"))
            gameObject.SetActive(false);
    }
}
