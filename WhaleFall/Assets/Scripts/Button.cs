using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("main Scene");
        PlayerPrefs.SetInt("Score", 0);
    }
}