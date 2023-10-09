using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class MainMenu : MonoBehaviour
{
    //connected to start button
    //when start button is pressed, this scene will activate.
    public void startGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    //connected to quit button
    public void quitGame()
    {
        Application.Quit();
    }
}
