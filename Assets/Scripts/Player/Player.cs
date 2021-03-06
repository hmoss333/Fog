﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//private MazeCell currentCell;

	//private MazeDirection currentDirection;

    public float speed;
    public float checkDist;
    public AudioSource footstepSource;

    float xInput;
    float zInput;

    float horizontal;
    float vertical;
    public float mouseSensitivity;

    Vector3 dir;
    Rigidbody rb;

    Vector3 previousGood = Vector3.zero;
    RaycastHit foundHit;

    GameManager gm;


    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        gm = GameObject.FindObjectOfType<GameManager>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdateRotation();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Movement Controls//
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        dir = new Vector3(xInput, 0, zInput); //causing issues with gravity    
        dir = transform.TransformDirection(dir);
        dir *= speed;

        rb.velocity = dir;

        rb.AddForce(Physics.gravity * (rb.mass * rb.mass));


        //Footstep Audio Controls//
        if ((xInput != 0 || zInput != 0) && !footstepSource.isPlaying)
            footstepSource.Play();
        else if (xInput == 0 && zInput == 0)
            footstepSource.Stop();


        //Interact Controls//
        if (Input.GetMouseButtonDown(0))//.GetButtonDown("Jump"))
        {
            foundHit = new RaycastHit();
            bool test = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out foundHit, checkDist, 1 << LayerMask.NameToLayer("Event"));
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);

            if (test)
            {
                foundHit.transform.GetComponent<InteractObject>().Interact();
            }
        }
    }

    void UpdateRotation()
    {
        horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        vertical -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        vertical = Mathf.Clamp(vertical, -30, 30);

        Camera.main.transform.localRotation = Quaternion.Euler(vertical, 0, 0);
        transform.Rotate(0, horizontal, 0);
    }
}