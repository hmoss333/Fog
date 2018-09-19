using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : InteractParent {

    public bool hasInteracted;

    private void Start()
    {
        if (PlayerPrefs.GetInt(this.gameObject.name.Substring(0, this.gameObject.name.LastIndexOf("(Clone)"))) == 1)
            hasInteracted = true;
        else
            hasInteracted = false;
    }

    public override void Interact()
    {
        base.Interact();

        if (!hasInteracted)
        {
            string tempName = this.gameObject.name.Substring(0, this.gameObject.name.LastIndexOf("(Clone)"));
            PlayerPrefs.SetInt(tempName, 1);

            GameManager.UpdateObjects(tempName, PlayerPrefs.GetInt(tempName));
            GameManager.interacted = true;
            Debug.Log(tempName + ": " + PlayerPrefs.GetInt(tempName));
        }
    }

    IEnumerator WaitForInput()
    {
        yield return new WaitForSeconds(0f);
        Debug.Log("Waiting for Input...");
    }
}
