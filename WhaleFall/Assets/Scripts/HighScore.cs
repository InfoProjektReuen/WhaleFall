using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("HighScore")){
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        }

        else if(PlayerPrefs.HasKey("HighScore") && PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore")){
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        }
    }

   
}
