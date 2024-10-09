using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public static bool difficultyHard = true;
    public int hiScore;
    public GameObject gameOverScreen;
    //public GameObject startGameScreen;
    public Text scoreText;
    public Text scoreInfo;
    public AudioSource dingSFX;
    public AudioSource gameMusic;
    public Text highScoreText;


    void Start()
    {
        gameMusic.Play();
        if (difficultyHard)
        {
            hiScore = PlayerPrefs.GetInt("HighScore-HARD", 0);
            scoreInfo.text = "hard highscore";
        }
        else
        {
            hiScore = PlayerPrefs.GetInt("HighScore", 0);
            scoreInfo.text = "easy highscore";
        }

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
            if (difficultyHard)
            {
                PlayerPrefs.SetInt("HighScore-HARD", hiScore);
            }
            else
            {
                PlayerPrefs.SetInt("HighScore", hiScore);
            }

            highScoreText.text = hiScore.ToString();
            PlayerPrefs.Save();
        }
    }



}
