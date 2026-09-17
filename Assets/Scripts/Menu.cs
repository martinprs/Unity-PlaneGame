using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject ControlsMenuCanvas;
    public GameObject EndMenuCanvas;
    public GameObject GameCanvas;
    public PlayerController playerController;
    public PostProcessVolume postProcessingVolume;

    private float flySpeedBeforeMenu;

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

    private void Awake()
    {
        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        if (postProcessingVolume == null)
        {
            postProcessingVolume = FindObjectOfType<PostProcessVolume>();
        }
    }

    public void Menu()
    {   
        SetPostProcessing(true);
        PauseFlight();
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
        SetPostProcessing(false);
        playerController.FlySpeed = flySpeedBeforeMenu;
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        ControlsMenuCanvas.SetActive(false);
        EndMenuCanvas.SetActive(false);
    }

    private void PauseFlight()
    {
        if (playerController.FlySpeed > 0)
        {
            flySpeedBeforeMenu = playerController.FlySpeed;
        }

        playerController.FlySpeed = 0;
    }

    private void SetPostProcessing(bool enabled)
    {
        if (postProcessingVolume != null)
        {
            postProcessingVolume.enabled = enabled;
        }
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