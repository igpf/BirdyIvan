using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdyIvanFlyScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicManagerScript logic;
    public Animator animator;
    public bool isAlive = true;
    public InputActionReference jump;
    public bool endFlight = false;

    
    
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (endFlight)
        {
             stopAnimator();
        }
        

        if (myRigidbody.position.x < -12.5 || myRigidbody.position.y < -7.5)
        {
            stopGame();
        }

    }

    private void OnEnable()
    {
        jump.action.started += Jump;
    }

    private void OnDisable()
    {
        jump.action.started -= Jump;
        
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        stopAnimator();
        animator.SetBool("isFlying", true);
        myRigidbody.velocity = Vector2.up * flapStrength;
        
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

    private void stopAnimator()
    {
        animator.SetBool("isFlying", false);
    }

}
