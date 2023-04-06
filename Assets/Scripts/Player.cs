using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float PlayerGrav;
    public static int Score;
    public static bool IsAlive;

    private static int MAX_ANGLE = 30;
    private static int MIN_ANGLE = -90;

    [SerializeField] private AudioClip flySFX;
    [SerializeField] private AudioClip pointSFX;
    [SerializeField] private AudioClip deathSFX;

    private AudioSource audioSource;
    private float jumpAmount = 130f;
    private float rotZ;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Score = 0;
        IsAlive = true;
    }

    void Update()
    {
        if (IsAlive)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) 
            {
                Jump();
            }
        }
        CheckRot();
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpAmount;
        audioSource.PlayOneShot(flySFX, 1);
    }

    void CheckRot()
    {
        rb.gravityScale = PlayerGrav;
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
                rotZ --;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Ground"))
        {
            IsAlive = false;
            audioSource.PlayOneShot(deathSFX, 1);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsAlive = false;
        audioSource.PlayOneShot(deathSFX, 1);
    }
    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Hitbox"))
        {
            Score++;
            audioSource.PlayOneShot(pointSFX, 1);
        }
    }
}
