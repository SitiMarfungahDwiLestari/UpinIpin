using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private int jumpCount = 0;
    public float moveSpeed = 5f;
    public int maxJumps = 2;
    private float minX;
    private HealthManager healthManager;
    private Vector3 currentCheckPoint;
    public AudioClip hitSound;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        healthManager = GetComponent<HealthManager>();
        currentCheckPoint = transform.position;
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
            if (AudioManager.Instance != null && hitSound != null)
            {
                AudioManager.Instance.musicSource.PlayOneShot(hitSound);
            }

            healthManager.TakeDamage();

            if (healthManager.currentHealth > 0)
            {
                transform.position = currentCheckPoint;  // Gunakan posisi checkpoint
                playerRb.velocity = Vector2.zero;
            }
            else
            {
                enabled = false;
                playerRb.velocity = Vector2.zero;
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            if (AudioManager.Instance != null && hitSound != null)
            {
                AudioManager.Instance.musicSource.PlayOneShot(hitSound);
            }
            healthManager.TakeDamage();
            if (healthManager.currentHealth > 0)
            {
                transform.position = currentCheckPoint;
                playerRb.velocity = Vector2.zero;
            }
            else
            {
                enabled = false;
                playerRb.velocity = Vector2.zero;
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    public void SetCheckPoint(Vector3 position)
    {
        currentCheckPoint = new Vector3(position.x, position.y + 1f, position.z); // Tambah sedikit Y agar tidak terjebak di tanah
        Debug.Log("New checkpoint position: " + currentCheckPoint);
    }
}