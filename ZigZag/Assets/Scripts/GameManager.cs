using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text playerScore;
    public Text highScore;

    public void StartGame()
    {
        gameStarted = true;
    }

    private void Awake()
    {
        highScore.text = $"Best Score: {GetHighScore().ToString()}";
        playerScore.text = $"Your Score: {score.ToString()}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }


    public void IncreaseScore()
    {
        score++;
        playerScore.text = $"Your Score: {score.ToString()}";
        if (score >= GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = $"Best Score: {score.ToString()}";
        }
    }

    int GetHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        return highScore;
    }
}
