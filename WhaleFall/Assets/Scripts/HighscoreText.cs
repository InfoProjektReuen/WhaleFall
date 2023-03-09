using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighscoreText : MonoBehaviour
{
    
    public TextMeshProUGUI _highScoreText;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); 
        

        _highScoreText.text = "Highscore: " + highScore;
    }

    
}
