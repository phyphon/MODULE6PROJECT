using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ColliderGrabObject : MonoBehaviour
{
    [SerializeField] SteamVR_Input_Sources handType;
    [SerializeField] SteamVR_Action_Boolean grabAction;
    [SerializeField] SteamVR_Behaviour_Pose controllerPose;

    GameObject collidingObject;
    GameObject objectInHand;

    int objectType; //0: trigger, 1: throwable, 2: pick up

    void SetCollidingObject(Collider col)
    {
        if (! collidingObject && col.GetComponent<Rigidbody>())
        {
            collidingObject = col.gameObject;

            //Determing what type of object it is / setting its color
            switch (collidingObject.gameObject.tag) {
                case "Trigger": objectType = 0; break;
                case "Throwable": objectType = 1; break;
                case "Pickup": objectType = 2; break;
                default: break;
            }

            print("Colliding!");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        collidingObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
        collidingObject.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }

    public void OnTriggerExit(Collider other)
    {
        if (collidingObject)
        {
            collidingObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

            collidingObject = null;
            print("Not colliding!");
        }
    }

    void GrabObject ()
    {
        if (objectType == 0) {
            objectInHand = collidingObject;
            collidingObject = null;

            if (!objectInHand.GetComponent<triggerAction>().highlighted) objectInHand.GetComponent<triggerAction>().trigger(); 

            print("T R I G G E R E D");
        } else {
            objectInHand = collidingObject;
            collidingObject = null;
            var joint = AddFixedJoint();
            joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
            print("Grabbed Object!");
        }
    }

    void ReleaseObject()
    {
        GetComponent<FixedJoint>().connectedBody = null;
        Destroy(GetComponent<FixedJoint>());

        //Throw if it is a throwable
        if (objectType == 1) {
            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
        }

        objectInHand = null;
        print("Released object!");
    }

    FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void Update()
    {
        if (grabAction.GetLastStateDown(handType)) 
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }
}
