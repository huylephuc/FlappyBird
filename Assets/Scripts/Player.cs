using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float PlayerGrav; 
    private float jumpAmount = 600f;
    private float rotZ = 30f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; 
        rb.velocity = Vector3.zero;
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
        rb.gravityScale = PlayerGrav;
        if (rb.velocity.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -rotZ);
        } else if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        } else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("hit");
    }
}
