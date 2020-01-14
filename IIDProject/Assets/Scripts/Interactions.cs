using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    //This script contains all interactions.
    public AudioManager AM;



    //Bird Timer
    void BirdTimer()
    {
        StartCoroutine(WaitThenChirp());
    }
    IEnumerator WaitThenChirp()
    {
        yield return new WaitForSeconds(5);
        AM.PlaySound("AudioClip1");
    }
}
