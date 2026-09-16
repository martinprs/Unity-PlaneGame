using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateCounter : MonoBehaviour
{
    private int gatesPassed = 0;

    public TextMeshProUGUI gateText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            gatesPassed++;
            gateText.text = $" {gatesPassed} / 5 Gates passed";
            Destroy(other.gameObject);
        }
    }
}
