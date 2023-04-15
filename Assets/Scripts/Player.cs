using UnityEngine;

public class Player : Subject
{
    public static Player Instance { get; private set; }
    private const int MAX_ANGLE = 30;
    private const int MIN_ANGLE = -90;

    private float jumpAmount = 4f;
    private float rotZ;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckRot();
        if (GameManager.instance.GameEnd) return;
        if (!GameManager.instance.IsStarted) return;
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.UpdateGameState(GameState.StartGame);
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpAmount;
        if (rb.gravityScale == 0) rb.gravityScale = 1;
        animator.SetTrigger("CanFly");
        AudioManager.instance.PlayAudio(2);
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

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (GameManager.instance.GameEnd) return;
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

    public void ChangeColor()
    {
        Debug.Log("Changed color");
    }
}
