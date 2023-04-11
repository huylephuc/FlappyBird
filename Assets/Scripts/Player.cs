using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Subject
{
    private const int MAX_ANGLE = 30;
    private const int MIN_ANGLE = -90;

    private float jumpAmount = 4f;
    private float rotZ;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if (GameManager.instance.GameEnd) return;
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) 
        {
            GameManager.instance.UpdateGameState(GameState.StartGame);
            Jump();
            //AudioManager.instance.PlayAudio(clip);
        }
        CheckRot();
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpAmount;
        if (rb.gravityScale == 0) rb.gravityScale = 1;
    }

    void CheckRot()
    {
        if (rb.velocity.y > 0)
        {
            if (rotZ < MAX_ANGLE)
            {
                rotZ += 15;
            }
        } else if (rb.velocity.y < 0)
        {
            if (rotZ > MIN_ANGLE) 
            {
                rotZ -= 5;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ground"))
        {
            GameManager.instance.UpdateGameState(GameState.EndGame);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.UpdateGameState(GameState.EndGame);
        GetComponent<Animator>().enabled = false;
    }
    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Hitbox"))
        {
            ScoreManager.instance.AddScore();
        }
    }
}
