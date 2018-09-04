using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {


    public float speed = 40;
    public GameObject ball;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = AIMove(0) * speed;
        //Debug.Log("move: " + move);
        rb.velocity = (new Vector3(0, move, 0));


        if (Input.GetKeyDown(KeyCode.Alpha1)) { this.transform.position = new Vector3(this.transform.position.x, 8, this.transform.position.z); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { this.transform.position = new Vector3(this.transform.position.x, 1, this.transform.position.z); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { this.transform.position = new Vector3(this.transform.position.x, -6, this.transform.position.z); }
    }

    float AIMove(int mode)
    {
        float BallY = ball.transform.position.y;
        float PaddleY = this.transform.position.y;
        float output = 0f;
        if(mode == 0)// easy
        {
            if (BallY < PaddleY - 0.5f) {
                output = -1f;
            }
            else if (BallY > PaddleY +0.5f)
            {
                output = 1f;
            }
            else
            {
                output = BallY - PaddleY;
            }


        }

        return output;
    }

}
