using UnityEngine;
using TMPro;  // Pastikan ini ada

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private MainManager mainManager;  // Tambahkan ini

    void Start()
    {
        UpdateScoreDisplay(); // Tampilkan score awal
    }


    void UpdateScoreDisplay()
    {
        if (MainManager.Instance != null)
        {
            Debug.Log("Current Score: " + MainManager.Instance.currentScore); // Debug
            scoreText.text = "Score: " + MainManager.Instance.currentScore;
        }
    }

    public void AddScore(int points)
    {
        MainManager.Instance.currentScore += points;
        UpdateScoreDisplay();
        Debug.Log("Added points: " + points); // Debug
    }
}