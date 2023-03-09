using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
private int highScore = 0; // Der Highscore-Wert wird initialisiert.

void Start()
{
    if(PlayerPrefs.HasKey("HighScore")) // �berpr�fen, ob ein Highscore-Wert in PlayerPrefs vorhanden ist.
    {
        highScore = PlayerPrefs.GetInt("HighScore"); // Wenn ja, den Highscore-Wert laden.
    }

    UpdateHighScore(); // Highscore-Wert aktualisieren.
}

public void UpdateHighScore()
{
    int score = PlayerPrefs.GetInt("Score"); // Den aktuellen Spielstand abrufen.

    if(score > highScore) // �berpr�fen, ob der aktuelle Spielstand den Highscore �bertrifft.
    {
        highScore = score; // Wenn ja, den Highscore aktualisieren.
        PlayerPrefs.SetInt("HighScore", highScore); // Highscore-Wert in PlayerPrefs speichern.
    }
}
}
