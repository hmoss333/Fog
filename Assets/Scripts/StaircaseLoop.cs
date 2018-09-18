using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StaircaseLoop : MonoBehaviour {

    public GameObject stairsTop;
    public int loopCount;

    // Use this for initialization
	void Start () {
        loopCount = Random.Range(5, 10); //Randomize the number of loops the player must complete before moving on
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector3(other.transform.position.x, stairsTop.transform.position.y, stairsTop.transform.position.z);

            if (loopCount != 0)
            {                
                loopCount--;
                Debug.Log(loopCount);
            }
            else
            {
                Debug.Log(loopCount);
                Debug.Log("ended loop");
                LevelManager.ChangeLevel("InfinityRoom");
            }
        }
    }
}
