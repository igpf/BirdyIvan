using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource gameOverSFX;

    void Start()
    {
        gameOverSFX.Play();
    }

    public void GoToMainMenuScence()
    {
        SceneManager.LoadScene("Menu");
    }


}
