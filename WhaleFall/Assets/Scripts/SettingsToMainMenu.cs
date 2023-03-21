using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
        {
            ReturnToMenu();
        }
    }
}
