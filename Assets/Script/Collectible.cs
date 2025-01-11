using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int scoreValue = 10;  // Nilai default

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Cari ScoreManager
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.AddScore(scoreValue);

            // Hilangkan collectible
            Destroy(gameObject);
        }
    }
}
