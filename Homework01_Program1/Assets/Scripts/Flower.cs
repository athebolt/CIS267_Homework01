using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flower : MonoBehaviour
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
            this.gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bug"))
        {
            Debug.Log("Hit");

            health = health - 1;

            collision.GetComponent<BugAI>().destroyBug();
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

    public void setHealth(int h)
    {
        health = h;
    }

    public int getHealth()
    {
        return health;
    }
}