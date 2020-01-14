using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTimer : MonoBehaviour
{
    [SerializeField] AudioManager AM;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(WaitThenYeet());
    }

    IEnumerator WaitThenYeet()
    {
        yield return new WaitForSeconds(5);
        AM.PlaySound("AudioClip1");
    }
}
