using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Collectables : MonoBehaviour
{
    //value of coin
    public int collectableValue;
    public int movementSpeed;
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

    
}
