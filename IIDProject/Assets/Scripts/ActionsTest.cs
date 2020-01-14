using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ActionsTest : MonoBehaviour
{
    [SerializeField] SteamVR_Input_Sources handType;
    [SerializeField] SteamVR_Action_Boolean grabAction;

    // Update is called once per frame
    void Update()
    {
        if (grabAction.GetState(handType))
        {
            print("Grab : " + handType);
        }
    }
}
