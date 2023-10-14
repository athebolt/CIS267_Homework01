using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    private GameObject flower;
    private Flowers fScript;
    private double rarity;

    private void Start()
    {
        rarity = 1;
    }

    private void Update()
    {
        //isGameOver();
    }

    private void isGameOver()
    {
        
    }

    public int bugRarity()
    {
        rarity = Time.deltaTime * .1;

        return (int)rarity;
    }

    public void platformSpawn()
    {
        
    }

}
