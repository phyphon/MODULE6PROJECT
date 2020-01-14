using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raccoon : MonoBehaviour
{
    public triggerAction letterTriggerScript;

    public bool touchingLetter;

    private void OnTriggerExit(Collider other)
    {
        if (touchingLetter == false)
        {
            touchingLetter = true;
            print("U N T R I G G E R R E D");

            letterTriggerScript.trigger();
        }
    }
}
