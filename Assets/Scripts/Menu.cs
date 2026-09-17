using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject ControlsMenuCanvas;
    public GameObject EndMenuCanvas;
    public GameObject GameCanvas;
    public PlayerController playerController;
    public PostProcessVolume postProcessingVolume;
    public TextMeshProUGUI announcerText;

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
        announcerText.text = "Paused";
        SetPostProcessing(true);
        PauseFlight(true);
        MenuCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        ControlsMenuCanvas.SetActive(false);
        EndMenuCanvas.SetActive(false);
    }

    public void ControlsMenu()
    {   
        announcerText.text = "Shortcut controls";
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(false);
        ControlsMenuCanvas.SetActive(true);
        EndMenuCanvas.SetActive(false);
    }

    public void ResumeGame()
    {
        announcerText.text = "";
        SetPostProcessing(false);
        PauseFlight(false);
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        ControlsMenuCanvas.SetActive(false);
        EndMenuCanvas.SetActive(false);
    }

    private void PauseFlight(bool enabled)
    {
        if (enabled)
        {
            if (playerController.FlySpeed > 0)
            {
                flySpeedBeforeMenu = playerController.FlySpeed;
            }

            playerController.FlySpeed = 0;
        }
        else
        {
            playerController.FlySpeed = flySpeedBeforeMenu;
        }
    }

    private void SetPostProcessing(bool enabled)
    {
        postProcessingVolume.enabled = enabled;
    }

    public void GameEnd(string text)
    {   
        announcerText.text = text;
        SetPostProcessing(true);
        PauseFlight(true);
        MenuCanvas.SetActive(false);
        GameCanvas.SetActive(false);
        ControlsMenuCanvas.SetActive(false);
        EndMenuCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}