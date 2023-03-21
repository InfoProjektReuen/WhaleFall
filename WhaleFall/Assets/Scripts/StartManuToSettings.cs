using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManuToSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public void ToSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
