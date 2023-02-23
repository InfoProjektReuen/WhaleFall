using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalScoreText : MonoBehaviour
{
    public GameManager myGameManager;
    public TextMeshProUGUI _scoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("Score"); // Versuchen, den gespeicherten Score zu bekommen, und den Standardwert auf -1 setzen, wenn kein Wert gefunden wird.
        

        _scoreText.text = "Score: " + score;
    }

    
}
