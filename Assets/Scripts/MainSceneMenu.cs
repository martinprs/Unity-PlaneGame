using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QuitGame();
        }
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
