using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateCounter : MonoBehaviour
{
    private int gatesPassed = 0;
    private PlayerController playerController;

    public TextMeshProUGUI gateText;
    public TextMeshProUGUI announcerText;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
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
                announcerText.text = "You win!";
            }

            Destroy(other.gameObject);
        }
    }
}
