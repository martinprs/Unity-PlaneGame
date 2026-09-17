using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject ControlsMenuCanvas;
    public GameObject EndMenuCanvas;
    public GameObject GameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        ControlsMenuCanvas.SetActive(false);
        EndMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ExitToMenu();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }

    public void Menu()
    {   
        MenuCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        ControlsMenuCanvas.SetActive(false);
        EndMenuCanvas.SetActive(false);
    }

    public void ControlsMenu()
    {   
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(false);
        ControlsMenuCanvas.SetActive(true);
        EndMenuCanvas.SetActive(false);
    }

    public void ExitControlsMenu()
    {   
        MenuCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        ControlsMenuCanvas.SetActive(false);
        EndMenuCanvas.SetActive(false);
    }

    public void ResumeGame()
    {   
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        ControlsMenuCanvas.SetActive(false);
        EndMenuCanvas.SetActive(false);
    }

    public void GameEnd()
    {   
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(false);
        ControlsMenuCanvas.SetActive(false);
        EndMenuCanvas.SetActive(true);
    }

    public void RestartGame() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ExitToMenu() {
        return;
        // Needs main menu scene
    }
}