using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetContinuing : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(delegate { Continue(); });
        PlayerPrefs.SetInt("continue", 0);
    }
	
	// Update is called once per frame
	void Continue()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("game_controller");
        if(gameController != null)
        {
            if (gameController.GetComponent<GameController>().canLoad)
            {
                PlayerPrefs.SetInt("continue", 1);
                SceneManager.LoadScene(3);
            }
        }        
    }
}
