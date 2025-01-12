using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            // Tidak perlu spawn ghost baru, hanya destroy diri sendiri
            Destroy(other.gameObject);  // Hancurkan peluru
            Destroy(gameObject);        // Hancurkan ghost
        }

        if (other.CompareTag("Player"))
        {
            HealthManager playerHealth = other.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();

                if (playerHealth.currentHealth <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                else
                {
                    PlayerController playerController = other.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        other.transform.position = playerController.currentCheckPoint;
                        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    }
                }
            }
        }
    }
}
    