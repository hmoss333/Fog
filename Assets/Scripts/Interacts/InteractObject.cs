using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : InteractParent {


    public override void Interact()
    {
        base.Interact();
        //player.itemCount++;
        //Destroy(this.gameObject);
    }

    IEnumerator WaitForInput()
    {
        yield return new WaitForSeconds(0f);
        Debug.Log("Waiting for Input...");
    }
}
