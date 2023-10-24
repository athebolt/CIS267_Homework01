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
    public GameObject player;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(isGameOver())
        {
            setGameOver(true);
        }
    }

    private bool isGameOver()
    {
        foreach(GameObject flower in flowers)
        {
            if(flower.GetComponent<Flower>().isDead())
            {
                return true;
            }
        }

        return false;
    }

    private void setGameOver(bool gameOver)
    {
        if(gameOver)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
            SaveData.SaveScore(player.GetComponent<Player>().getPlayerScore());
        }
        else
        {
            gameOverScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
