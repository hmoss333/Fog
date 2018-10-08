using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {

    Player player;
    public Vector3 lookDir;
    
    // Use this for initialization
	void OnEnable() {
        player = GameObject.FindObjectOfType<Player>();
	}

    // Update is called once per frame
    void Update () {
        if (player)
            transform.LookAt(player.transform.position);

        lookDir = transform.rotation.eulerAngles;
	}
}
