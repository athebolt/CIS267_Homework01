using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flowers : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead())
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bug"))
        {
            Debug.Log("Hit");
            health--;
        }
    }

    //if the flower has 0 health, it is dead.
    public bool isDead()
    {
        if(health == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
