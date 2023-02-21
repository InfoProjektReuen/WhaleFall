using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameManager myGameManager;
    
    

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("StartMenu");
        myGameManager._gameOver = false;
    }
}
