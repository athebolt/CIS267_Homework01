using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Burst;

public class Player : MonoBehaviour
{
    //private variables
    private Rigidbody2D playerRigidBody;
    private float inputHorizontal;
    private bool canJump;
    private double playerScore;
    private Animator playerAnimator;

    //public variables, will appear in the inspector
    public float playerSpeed;
    public float acceleration;
    public float maxSpeed;
    public float jumpForce;
    public TMP_Text guiScore;
    public GameObject respawn;
    public GameObject[] flowers;
    public GameObject shield;
    
    //========================================================================================
    //START AND UPDATE
    //========================================================================================

    // Start is called before the first frame update
    void Start()
    {
        //getting the rigidbody component from the player and assigning it to the variable "playerRigidBody"
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerScore = 0;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();
        chargeJump();
        playerScoreFormula();
        updatePlayerScore();
        playerJump();
    }

    //========================================================================================
    //PLAYER MOVEMENT
    //========================================================================================

    private void movePlayerLateral()
    {
        if(inputHorizontal == 0)
        {
            playerSpeed = 1;
        }

        //will get horizontal input of the keyboard (a or d/left or right arrow keys)
        //left is -1
        //right is 1
        //none is 0
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        playerRigidBody.velocity = new Vector2(playerSpeed * inputHorizontal, playerRigidBody.velocity.y);

        playerSpeed += acceleration;

        if(playerSpeed >= maxSpeed)
        {
            playerSpeed = maxSpeed;
        }
    }

    private void chargeJump()
    {
        //while the player holds space on the ground, the player changes their jump to a max of 10
        if(Input.GetKey(KeyCode.Space) && jumpForce <= 20)
        {
            Debug.Log("Charing Jump");


            jumpForce += Time.deltaTime * 10;

            playerAnimator.SetBool("isJumpCharge", true);
        }
    }

    private void playerJump()
    {
        if(Input.GetKeyUp(KeyCode.Space) && canJump)
        {
            playerAnimator.SetBool("isJumpCharge", false);

            playerAnimator.SetTrigger("jumpReleased");

            //once the player releases space, or the jump maxes at 10, the player jumps
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);

            jumpForce = 3;

            canJump = false;
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
            //respawn player if there is a collsion with the boundary
            this.transform.position = new Vector2(respawn.transform.position.x, respawn.transform.position.y);
        }
        else if(collision.gameObject.CompareTag("Ground"))
        {
            //if the player is colliding with the ground, then the player is grounded
            canJump = true;
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
        }
        else if(collision.gameObject.CompareTag("Bug"))
        {
            int bugValue = collision.GetComponent<BugAI>().getBugValue();

            playerScore += bugValue;

            collision.GetComponent<BugAI>().destroyBug();
        }
        else if(collision.gameObject.CompareTag("Heal"))
        {
            foreach(GameObject flower in flowers)
            {
                flower.GetComponent<Flower>().setHealth(3);
            }
        }
        else if(collision.gameObject.CompareTag("ShieldActivator"))
        {
            shield.SetActive(true);
        }
        else if(collision.gameObject.CompareTag("Bomb"))
        {
            FindAnyObjectByType<BugAI>().destroyBug();
            
            FindAnyObjectByType<BugAI>().destroyBug();
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
