using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordingTimerText : MonoBehaviour {

    public Text recordingText;
    private bool timerActive = false;
    public float recordTime;
    private float timer;

	// Use this for initialization
	void Start () {
        timer = recordTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
        {
            if (!timerActive)
            {
                timerActive = true;
            }
            else
            {
                ResetTimer();
            }
        }
            
        if (timerActive)
        {
            recordingText.text = "Recording " + timer;
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                ResetTimer();
            }
        }
	}

    void ResetTimer()
    {
        timerActive = false;
        timer = recordTime;
        recordingText.text = "";
    }
}
