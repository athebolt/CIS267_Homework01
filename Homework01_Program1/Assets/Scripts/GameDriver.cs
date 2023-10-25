using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using TMPro;


public class GameDriver : MonoBehaviour 
{
    public GameObject[] flowers;
    public GameObject gameOverScreen;
    public GameObject player;
    public TMP_Text guiFlowerHealth;
    public float acceleration;
    private float timePassed;

    private void Start()
    {
        timePassed = 0f;
    }

    private void Update()
    {
        timePassed += Time.deltaTime;

        if(isGameOver())
        {
            setGameOver(true);
        }

        flowerHealthDisplay();
        
        if(timePassed >= 1f)
        {
            Time.timeScale += acceleration;

            timePassed = 0f;
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

    private void flowerHealthDisplay()
    {
        guiFlowerHealth.text = "Flower Health: " + flowers[0].GetComponent<Flower>().getHealth() + ", " + flowers[1].GetComponent<Flower>().getHealth() + ", " + flowers[2].GetComponent<Flower>().getHealth() + ", " + flowers[3].GetComponent<Flower>().getHealth();
    }
}
