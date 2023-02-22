using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTextUI : MonoBehaviour
{
    public GameManager myGameManager;
    public TextMeshProUGUI scoreText;
    
    void Start(){
        
        scoreText.text = "Score: " + myGameManager._score.ToString();
    }

    void Update()
    {
        scoreText.text = "Score: " + myGameManager._score.ToString();
    }
}
