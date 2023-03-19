using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameManager myGameManager;
    
    

    public void ReturnToMenu()
    {
        if (SceneManager.GetActiveScene().name == "GameOverScreen")
        {
            SceneManager.LoadScene("StartMenu");

            myGameManager = GameObject.FindObjectOfType<GameManager>();
            if (myGameManager != null)
            {
                myGameManager._gameOver = false;
            }
        }
    }
}
