using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour {

    private static Renderer[] childMaTS;
    public Shader staticShader;
    bool hasInteracted;
    float waitTime = 1.5f;

    public AudioSource interactSource;

    private void Start()
    {
        childMaTS = GetComponentsInChildren<Renderer>();

        if (PlayerPrefs.GetInt(this.gameObject.name.Substring(0, this.gameObject.name.LastIndexOf("(Clone)"))) == 1)
        {
            hasInteracted = true;
            SetStaticShader();
        }
        else
            hasInteracted = false;
    }

    public void Interact()
    {
        if (!hasInteracted)
        {
            SetStaticShader();
            interactSource.Play();
            hasInteracted = true;

            StartCoroutine(WaitForInput(waitTime));
        }
    }

    private void SetStaticShader ()
    {
        for (int i = 0; i < childMaTS.Length; i++)
        {
            childMaTS[i].material.shader = staticShader;
        }
    }

    IEnumerator WaitForInput(float waitTime)
    {
        string tempName = this.gameObject.name.Substring(0, this.gameObject.name.LastIndexOf("(Clone)"));
        PlayerPrefs.SetInt(tempName, 1);

        yield return new WaitForSeconds(waitTime);
        GameManager.UpdateObjects(tempName, PlayerPrefs.GetInt(tempName));
        GameManager.interacted = true;
    }
}
