using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private int jumpCount = 0;
    public float moveSpeed = 5f;
    public int maxJumps = 2;
    private float minX;
    private HealthManager healthManager;
    private Vector3 startPosition;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        healthManager = GetComponent<HealthManager>();
        startPosition = transform.position;
    }

    void Update()
    {
        minX = Camera.main.transform.position.x - 9f;

        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveHorizontal * moveSpeed * Time.deltaTime);

        if (transform.position.x < minX)
        {
            Vector3 playerPos = transform.position;
            playerPos.x = minX;
            transform.position = playerPos;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumps)
        {
            playerRb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }

        if (collision.gameObject.CompareTag("Saw"))
        {
            healthManager.TakeDamage();

            if (healthManager.currentHealth > 0)  // Diubah dari GetCurrentHealth()
            {
                transform.position = startPosition;
                playerRb.velocity = Vector2.zero;
            }
            else
            {
                enabled = false;
                playerRb.velocity = Vector2.zero;
            }
        }
    }
}