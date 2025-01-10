using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private bool isOnGround = true;
    private int jumpCount = 0;
    public float moveSpeed = 5f;
    public int maxJumps = 2;

    void Start()
    { 
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveHorizontal * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < maxJumps)
        {
           playerRb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  // Ini untuk 2D
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpCount = 0;
        }
    }
}
