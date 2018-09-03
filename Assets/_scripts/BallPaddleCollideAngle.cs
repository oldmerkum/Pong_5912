using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPaddleCollideAngle : MonoBehaviour {

    private string paddle = "paddle";
    private float reactSpeed = 10f;

    public float minimumXSpeed = 5f;
    public float minimumSpeed = 20f;

    void OnCollisionEnter(Collision paddleCol)
    {
        if (paddleCol.gameObject.CompareTag(paddle))
            ReactToBallCollision(paddleCol.collider);
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

    public void LateUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Scale speed to minimum if still necessary
        if (rb.velocity.magnitude < minimumSpeed)
            rb.velocity = rb.velocity.normalized * minimumSpeed;

        // Scale x speed to minimum, so ball doesn't take forever to get across
        if (Mathf.Abs(rb.velocity.x) < minimumXSpeed)
            rb.velocity = new Vector3(minimumXSpeed * (rb.velocity.x < 0 ? -1 : 1), rb.velocity.y, rb.velocity.z);
    }
}
