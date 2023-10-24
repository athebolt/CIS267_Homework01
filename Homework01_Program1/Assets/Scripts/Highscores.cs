using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscores : MonoBehaviour
{
    public TMP_Text guiHighScore;

    // Start is called before the first frame update
    void Start()
    {
        guiHighScore.text = SaveData.LoadScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
