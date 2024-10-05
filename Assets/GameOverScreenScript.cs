using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class GameOverScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource gameOverSFX;
    
    void Start()
    {
        gameOverSFX.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
