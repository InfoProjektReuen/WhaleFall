using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public bool gameStarted;

    public void StartGame()
    {
        SceneManager.LoadScene("main Scene");
        PlayerPrefs.SetInt("Score", 0);
        gameStarted = true;
    }
}