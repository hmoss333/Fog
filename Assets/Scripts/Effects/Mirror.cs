using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

    Player player;
    
    // Use this for initialization
	void OnEnable() {
        player = GameObject.FindObjectOfType<Player>();
	}

    // Update is called once per frame
    void Update () {
        if (player)
            transform.LookAt(player.transform.position);
	}
}
