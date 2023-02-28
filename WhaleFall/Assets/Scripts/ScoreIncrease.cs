using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrease : MonoBehaviour
{
    public GameManager myGameManager;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("NormalerWal"))
        {
            myGameManager._score += 5;
            PlayerPrefs.SetInt("Score", myGameManager._score);
            PlayerPrefs.Save();
        }
        if (other.gameObject.CompareTag("GigaWal"))
        {
            myGameManager._score += 10;
            PlayerPrefs.SetInt("Score", myGameManager._score);
            PlayerPrefs.Save();
        }
    }
}