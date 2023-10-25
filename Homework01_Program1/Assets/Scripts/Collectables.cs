using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Collectables : MonoBehaviour
{
    //value of coin
    public int collectableValue;
    public float movementSpeed;
    public float endPos;

    private void Update()
    {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);

        if (transform.position.y <= endPos)
        { 
            Destroy(this.gameObject);
        }
    }

    public void destroyCollectable()
    {
        //destroys the collectable
        Destroy(this.gameObject);
    }

    public void setCollectableValue(int v)
    {
        collectableValue = v;
    }

    public int getCollectableValue()
    {
        //returns collectable value
        return collectableValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            destroyCollectable();
        }
    }
}
