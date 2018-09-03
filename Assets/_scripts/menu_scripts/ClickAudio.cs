using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickAudio : MonoBehaviour {
	private GameObject audioManager;
	private AudioSource click;
	void Start()
	{
		audioManager = GameObject.Find ("AudioManager");
		var audioSources = audioManager.GetComponents<AudioSource> ();
		click = audioSources [0];
		GetComponent<Button>().onClick.AddListener(delegate { clickAudio(); });
	}
	public void clickAudio()
	{
		click.Play ();
	}
}