using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BugAI : MonoBehaviour
{
    public int movementSpeed;
    public int bugValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
    }

    public int getBugValue()
    {
        return bugValue;
    }

    public void destroyBug()
    {
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            destroyBug();
        }
    }
}
