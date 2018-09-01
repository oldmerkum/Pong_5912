using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressPause : MonoBehaviour {
    public GameObject pausePanel;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P)) pauseOrUnpause();
	}
    private void pauseOrUnpause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }
}
