using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour {

    public Transform rotatePoint;
    public float rotateSpeed;

    public enum Direction { left, right }
    public Direction direction;

    // Use this for initialization
    void Start () {
        rotateSpeed = (direction == Direction.left) ? rotateSpeed : -rotateSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(rotatePoint.position, rotatePoint.up, rotateSpeed * Time.deltaTime);
    }
}
