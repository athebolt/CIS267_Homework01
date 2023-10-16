using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;


public class GameDriver : MonoBehaviour 
{
    public GameObject[] flowers;
    public GameObject gameOverScreen;
    private int deadFlowers;

    private void Start()
    {
        
    }

    private void Update()
    {
        isGameOver();
    }

    private void isGameOver()
    {
        deadFlowers = 0;

        foreach(GameObject flower in flowers)
        {
            if(flower.GetComponent<Flower>().isDead())
            {
                deadFlowers++;
            }
        }

        if(deadFlowers == 4)
        {
            //game is over
            Debug.Log("Game Over");

            Time.timeScale = 0f;
            
            gameOverScreen.SetActive(true);
        }
    }

    private void evaluateGameState()
    {
        
    }
}
