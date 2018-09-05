using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDebugGUI : MonoBehaviour {
    public GameObject Paddle;
    private GameObject ball;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
    }
    void OnGUI()
    {
        //make background box
        GUILayout.Box("Test Menu");
        GUILayout.Box("ball position: " + ball.GetComponent<Rigidbody>().position);
        GUILayout.Box("ball velocity: " + ball.GetComponent<Rigidbody>().velocity);
        if (GUILayout.Button("Increase Ball Velocity"))
        {
            ball.GetComponent<Rigidbody>().velocity *= 1.2f;
        }
        if (GUILayout.Button("Decrease Ball Velocity"))
        {
            ball.GetComponent<Rigidbody>().velocity *= .8f;
        }
        if (GUILayout.Button("Reset P2 Paddle"))
        {
            Paddle.transform.position = new Vector3(Paddle.transform.position.x, 1, Paddle.transform.position.z);
        }
        if (GUILayout.Button("Reset Ball Position"))
        {
            ball.transform.position = new Vector3(0, 0.5f, Paddle.transform.position.z);
        }
    }
}
