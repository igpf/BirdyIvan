using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public static bool difficultyHard = true;
    public int hiScore;
    public GameObject gameOverScreen;
    //public GameObject startGameScreen;
    public Text scoreText;
    public AudioSource dingSFX;
    public AudioSource gameMusic;
    public Text highScoreText;


    void Start()
    {
        gameMusic.Play();
        hiScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = hiScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        dingSFX.Play();

        checkHighScore();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        gameMusic.Play();
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameMusic.Stop();

    }

    public void ExitGame()
    {
        Application.Quit();
    }


    public void checkHighScore()
    {
        if (playerScore > hiScore)
        {
            hiScore = playerScore;
            PlayerPrefs.SetInt("HighScore", hiScore);
            highScoreText.text = hiScore.ToString();
            PlayerPrefs.Save();
        }
    }

}
