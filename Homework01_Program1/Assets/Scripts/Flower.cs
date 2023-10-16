using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Flower : MonoBehaviour
{
    public int health;
    public TMP_Text guiFlowerHealth;

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

        guiFlowerHealth.text = health.ToString();
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
}