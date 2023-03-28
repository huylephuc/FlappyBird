using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float jumpAmount = 100f;
    private float rotZ = 30f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckRot();
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) 
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpAmount;
    }

    void CheckRot()
    {
        if (rb.velocity.y <= 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -rotZ);
        } else
        {
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }
}
