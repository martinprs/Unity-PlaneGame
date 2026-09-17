using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateCounter : MonoBehaviour
{
    private int gatesPassed = 0;
    private PlayerController playerController;
    private MainMenu mainMenu;

    public TextMeshProUGUI gateText;
    public TextMeshProUGUI announcerText;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        mainMenu = FindObjectOfType<MainMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            gatesPassed++;

            playerController.FlySpeed += 5f;

            gateText.text = $" {gatesPassed} / 10 Gates passed";

            if (gatesPassed >= 10)
            {
                mainMenu.GameEnd("You win!");
            }

            Destroy(other.gameObject);
        }
    }
}
