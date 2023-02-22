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
        _scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
    }

    
}
