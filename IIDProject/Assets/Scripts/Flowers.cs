using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour
{
    public triggerAction triggerScript;

    public bool triggeringButterflies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Butterfly"))
        {
            triggeringButterflies = true;
            print("T O U C H I N G B U T T E R F L I E S");

            triggerScript.trigger();
        }
    }
}
