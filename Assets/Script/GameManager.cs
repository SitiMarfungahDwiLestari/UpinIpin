using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        MainManager.Instance.ResetScore();
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        MainManager.Instance.DeleteHighScore(); 
        SceneManager.LoadScene(1);
    }

    public void HighScore()
    {
        MainManager.Instance.ResetScore();
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        MainManager.Instance.ResetScore();  
        SceneManager.LoadScene(1);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
