using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBallMovement : MonoBehaviour {
    public Vector3 startForce = new Vector3(500, 0, 0);
	void Start () {
        GetComponent<Rigidbody>().AddForce(startForce);
	}
}
