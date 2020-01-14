using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eavesdrop : MonoBehaviour
{
    public triggerAction triggerScript;

    public bool eavesdropping;

    private void OnTriggerEnter(Collider other)
    {
        eavesdropping = true;
        print("E A V E S D R O P P I N G");

        triggerScript.trigger();
    }
}
