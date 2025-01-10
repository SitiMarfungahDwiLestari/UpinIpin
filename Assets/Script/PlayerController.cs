using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private bool isOnGround = true;
    private int jumpCount = 0;
    public float moveSpeed = 5f;
    public int maxJumps = 2;
    private float minX;  

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Update batas kiri player berdasarkan posisi kamera
        minX = Camera.main.transform.position.x - 9f;

        // Gerakan kanan kiri
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveHorizontal * moveSpeed * Time.deltaTime);

        // Batasi gerakan ke kiri
        if (transform.position.x < minX)
        {
            Vector3 playerPos = transform.position;
            playerPos.x = minX;
            transform.position = playerPos;
        }

        // Lompat
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
            isOnGround = true;
            jumpCount = 0;
        }

        // Tambahkan ini untuk mendeteksi saw
        if (collision.gameObject.CompareTag("Saw"))
        {
            // Nonaktifkan kontrol player
            enabled = false;

            // Optional: Bisa tambahkan efek
            // Destroy(gameObject);  // Jika ingin player hancur
            // atau
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;  // Berhenti bergerak
        }
    }
}