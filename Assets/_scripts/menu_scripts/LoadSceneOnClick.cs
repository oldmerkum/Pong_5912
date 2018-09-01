using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneOnClick : MonoBehaviour {
    public int startSceneIndex;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { LoadByIndex(startSceneIndex); });
    }
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
