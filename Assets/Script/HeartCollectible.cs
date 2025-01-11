using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthManager playerHealth = collision.GetComponent<HealthManager>();

            // Cek apakah health belum penuh
            if (playerHealth.currentHealth < playerHealth.maxHealth)
            {
                playerHealth.AddHealth(1);  // Tambah health
                Destroy(gameObject);  // Hilangkan heart collectible
            }
        }
    }
}
