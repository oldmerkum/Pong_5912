using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckContinuing : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("continue") == 1){
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("game_controller").GetComponent<GameController>().Load();              
        }
	}
}
