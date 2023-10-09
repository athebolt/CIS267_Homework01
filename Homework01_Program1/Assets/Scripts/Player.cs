using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;
using TMPro;

public class Player : MonoBehaviour
{
    //private variables
    private Rigidbody2D playerRigidBody;
    private float inputHorizontal;
    private bool isGrounded;
    private double playerScore;
    private Collectables collectable;

    //public variables, will appear in the inspector
    public float movementSpeed;
    public float jumpForce;
    public TMP_Text guiScore;
    
    //========================================================================================
    //START AND UPDATE
    //========================================================================================

    // Start is called before the first frame update
    void Start()
    {
        //getting the rigidbody component from the player and assigning it to the variable "playerRigidBody"
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        playerJump();
        playerScoreFormula();
        updatePlayerScore();
    }

    //========================================================================================
    //PLAYER MOVEMENT
    //========================================================================================

    //temp movement will be improved
    private void movePlayerLateral()
    {
        //will get horizontal input of the keyboard (a or d/left or right arrow keys)
        //left is -1
        //right is 1
        //none is 0
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        playerRigidBody.velocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.velocity.y);
    }

    private void playerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //if the user presses space, and the player is grounded, then jump
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }
    }

    //========================================================================================
    //PLAYER COLLISIONS AND TRIGGERS
    //========================================================================================
    
    //Whenever the player collides with something, check what it collided with
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("OB"))
        {
            //reload the screen if there is a collsion in the boundary
            SceneManager.LoadScene(GAME_SCENE);
        }
        else if(collision.gameObject.CompareTag("Ground"))
        {
            //if the player is colliding with the ground, then the player is grounded
            isGrounded = true;
        }
    }

    //if the player is no longer colliding with something, check what it is
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            //if the player is not touching the ground, then the player is not grounded
            isGrounded = false;
        }
    }

    //if the object the player collides with is a trigger, check what is
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            //gets the collectable value of the component which is a collectable of the object the player collided with
            int collectableValue = collision.GetComponent<Collectables>().getCollectableValue();

            //add the collectable value of the object to the player's score
            playerScore += collectableValue;

            //destroys the collectable
            collision.GetComponent<Collectables>().destroyCollectable();
        }
    }

    //========================================================================================
    //PLAYER SCORE
    //========================================================================================

    public int getPlayerScore()
    {
        return (int)playerScore;
    }

    public void playerScoreFormula()
    {
        playerScore = playerScore + Time.deltaTime;
    }

    public void updatePlayerScore()
    {
        guiScore.text = "Score: " + getPlayerScore();
    }
}
