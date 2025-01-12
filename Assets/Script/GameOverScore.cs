using UnityEngine;
using TMPro;
public class GameOverScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;    // Reference ke Text Final Score
    public TextMeshProUGUI highScoreText;     // Reference ke Text High Score

    void Start()
    {
        if (MainManager.Instance != null)
        {
            Debug.Log("GameOver Score: " + MainManager.Instance.currentScore); // Debug

            finalScoreText.text = "" + MainManager.Instance.currentScore;

            // Update high score jika perlu
            if (MainManager.Instance.currentScore > MainManager.Instance.highScore)
            {
                MainManager.Instance.highScore = MainManager.Instance.currentScore;
            }
            highScoreText.text = "High Score: " + MainManager.Instance.highScore;
        }
        else
        {
            Debug.LogError("MainManager not found!");
        }
    }
}