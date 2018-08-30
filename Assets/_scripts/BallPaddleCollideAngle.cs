using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaddleCollideAngle : MonoBehaviour {
    private string paddle = "paddle";
    private float reactSpeed = 10f;
    void OnCollisionEnter(Collision paddleCol)
    {
        if (paddleCol.gameObject.CompareTag(paddle)) ReactToBallCollision(paddleCol.collider);
    }
    private void ReactToBallCollision(Collider paddleCol)
    {
        float y = hitFactor(transform.position, paddleCol.transform.position, paddleCol.bounds.size.y);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, y * reactSpeed, 0));
    }
    private float hitFactor(Vector3 ballPos, Vector3 paddlePos, float paddleHeight)
    {
        return (ballPos.y - paddlePos.y) / paddleHeight;
    }
}
