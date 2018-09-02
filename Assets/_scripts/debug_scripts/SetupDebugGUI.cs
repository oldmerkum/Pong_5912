using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupDebugGUI : MonoBehaviour {
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
    }
}
