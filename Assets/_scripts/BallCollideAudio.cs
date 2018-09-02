using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollideAudio : MonoBehaviour {
	private string wall = "wall";
	private string paddle = "paddle";
	private string goal = "goal";
	private GameObject audioManager;
	private AudioSource paddleHit;
	private AudioSource wallHit;
	private AudioSource goalHit;

	void Awake () {
		audioManager = GameObject.Find ("AudioManager");
		var audioSources = audioManager.GetComponents<AudioSource> ();
		paddleHit = audioSources [0];
		wallHit = audioSources [1];
		goalHit = audioSources [2];
	}
	void OnCollisionEnter(Collision ballCol)
	{
		if (ballCol.gameObject.CompareTag(paddle)) audioPlay(paddle);
		if (ballCol.gameObject.CompareTag(wall)) audioPlay(wall);
		if (ballCol.gameObject.CompareTag(goal)) audioPlay (goal);
	}
	void audioPlay(string audio)
	{
		if (audio == paddle) {
			paddleHit.Play ();
		}
		if (audio == wall) {
			wallHit.Play ();
		}
		if (audio == goal) {
			goalHit.Play ();
		}
	}
}
