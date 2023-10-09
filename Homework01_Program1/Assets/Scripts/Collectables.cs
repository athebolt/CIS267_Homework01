using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    //value of coin
    public int collectableValue;

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
