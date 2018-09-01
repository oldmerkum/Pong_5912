using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeTimeScaleOnClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(SetTimeScaleToOne);
	}
    public void SetTimeScaleToOne()
    {
        Time.timeScale = 1;
    }
}
