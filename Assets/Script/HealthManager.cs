// HealthManager.cs
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;  // Diubah jadi public
    public Image heartPrefab;
    private GameObject healthDisplay;

    void Start()
    {
        currentHealth = maxHealth;
        healthDisplay = GameObject.Find("HealthDisplay");
        DisplayHearts();
    }

    void DisplayHearts()
    {
        // Hapus heart yang lama
        foreach (Transform child in healthDisplay.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < currentHealth; i++)
        {
            Image heart = Instantiate(heartPrefab);
            heart.transform.SetParent(healthDisplay.transform, false);
            // Ubah posisi ke pojok kiri atas
            heart.rectTransform.anchoredPosition = new Vector2(10 + (i * 30), -10);
            // X: 10 = jarak dari kiri
            // i * 40 = jarak antar heart
            // Y: -10 = jarak dari atas
        }
    }

    public void AddHealth(int amount)
    {
        // Tambah health tapi tidak melebihi maxHealth
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        DisplayHearts();
    }

    public void TakeDamage()
    {
        currentHealth--;
        DisplayHearts();
    }
}