using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour {

    public GameObject fireEffect;
    bool hasInteracted;
    float waitTime = 1.5f;

    public AudioSource interactSource;

    private void Start()
    {
        if (PlayerPrefs.GetInt(this.gameObject.name.Substring(0, this.gameObject.name.LastIndexOf("(Clone)"))) == 1)
        {
            hasInteracted = true;
            fireEffect = Instantiate(fireEffect, this.gameObject.transform);
        }
        else
            hasInteracted = false;
    }

    public void Interact()
    {
        if (!hasInteracted)
        {
            fireEffect = Instantiate(fireEffect, this.gameObject.transform);
            interactSource.Play();
            hasInteracted = true;

            StartCoroutine(WaitForInput(waitTime));
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
