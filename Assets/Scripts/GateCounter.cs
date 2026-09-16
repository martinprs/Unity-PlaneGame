using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateCounter : MonoBehaviour
{
    private int gatesPassed = 0;

    public TextMeshProUGUI gateText;
    public TextMeshProUGUI announcerText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            gatesPassed++;
            gateText.text = $" {gatesPassed} / 5 Gates passed";

            if (gatesPassed >= 5)
            {
                announcerText.text = "You win!";
            }

            Destroy(other.gameObject);
        }
    }
}
