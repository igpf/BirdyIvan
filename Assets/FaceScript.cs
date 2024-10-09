using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicManagerScript logic;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0) && isAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (myRigidbody.position.x < -12.5 || myRigidbody.position.y < -7.5)
        {
            stopGame();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LogicManagerScript.difficultyHard)
        {
            stopGame();
        }

    }

    void stopGame()
    {
        logic.gameOver();
        isAlive = false;
    }
}
