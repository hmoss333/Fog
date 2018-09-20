using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTimer : MonoBehaviour {

    LevelManager lm;
    public float waitTime;
    
    // Use this for initialization
	void Start () {
        lm = GameObject.FindObjectOfType<LevelManager>();

        StartCoroutine(WaitToEnd(waitTime));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator WaitToEnd(float waitTime)
    {
        Debug.Log("Started timer");

        yield return new WaitForSeconds(waitTime);

        LevelManager.ChangeLevel("MainMenu");
    }
}
