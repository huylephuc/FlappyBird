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
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        CheckRot();
        if (GameManager.instance.GameEnd) return;
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) 
        {
            GameManager.instance.UpdateGameState(GameState.StartGame);
            Jump();
            AudioManager.instance.PlayAudio(2);
        }
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
        if (collider.CompareTag("Hitbox"))
        {
            ScoreManager.instance.AddScore();
            AudioManager.instance.PlayAudio(1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance.GameEnd) return;
        AudioManager.instance.PlayAudio(0);
        GameManager.instance.UpdateGameState(GameState.EndGame);
        GetComponent<Animator>().enabled = false;
        rb.Sleep();
    }
}
