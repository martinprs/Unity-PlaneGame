using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCounter : MonoBehaviour
{
    private int gatesPassed = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate"))
        {
            gatesPassed++;
            Destroy(other.gameObject);
        }
    }
}
