using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public float direction = 1f;  // Tambahkan ini, default ke kanan

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Gunakan direction untuk menentukan arah
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}