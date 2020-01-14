using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAction : MonoBehaviour
{
    [SerializeField] AudioManager AM;
    public bool highlighted = false;
    private float a = 1.0f;

    public void trigger()
    {
        AM.PlaySound("AudioClip1");
        StartCoroutine(WaitThenYeet());
        highlighted = true;
    }

    IEnumerator WaitThenYeet()
    {
        yield return new WaitForSeconds(AM.sounds[0].clip.length);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (highlighted) {

            if (a > 0f) a -= 0.05f;
            else a = 0f;

            GetComponent<Renderer>().material.SetColor("_Color", new Color(GetComponent<MeshRenderer>().material.color.r, GetComponent<MeshRenderer>().material.color.g, GetComponent<MeshRenderer>().material.color.b, a));
            GetComponent<Renderer>().material.SetColor("_OutlineColor", new Color(GetComponent<MeshRenderer>().material.color.r, GetComponent<MeshRenderer>().material.color.g, GetComponent<MeshRenderer>().material.color.b, a));
        }
    }
}

