using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSidetoSide : MonoBehaviour
{
    private bool moveRight;
    public float movementSpeed;
    public float leftBoundary;
    public float rightBoundary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    private void movePlatform()
    {
        if(moveRight)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }

        if(transform.position.x <= leftBoundary)
        {
            moveRight = true;
        }
        else if(transform.position.x >= rightBoundary)
        {
            moveRight = false;
        }
    }
}
