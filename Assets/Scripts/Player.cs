using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float PlayerGrav;
    public static int Score;
    public static bool IsAlive;
    public GameManager gameManager;

    private float jumpAmount = 130f;
    private float rotZ = 30f;
    private Rigidbody2D rb;

    private void OnEnable()
    {
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        Score = 0;
        IsAlive = true;
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
            PlayerGrav++;
        } else if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Pipe") || collider.CompareTag("Ground"))
        {
            IsAlive = false;
        }
    }
    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Hitbox"))
        {
            Score++;
        }
    }
}
