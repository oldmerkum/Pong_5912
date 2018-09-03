using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    public string paddleInput;
    public float speed = 40;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxisRaw(paddleInput) * speed;
        //Debug.Log("move: " + move);
        rb.velocity = (new Vector3(0, move, 0));
	}
}
