using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDebugging : MonoBehaviour {
    public GameObject debugGUI;
	void Update () {
        if (Input.GetKeyDown(KeyCode.T)) debugGUI.SetActive(!debugGUI.activeSelf);
	}
}
