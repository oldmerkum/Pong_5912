using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWinState : MonoBehaviour {
	private string goal = "goal";
	private Vector3 restartForce = new Vector3 (5, 0, 0);
	void OnCollisionEnter(Collision ballCol)
	{
		if (ballCol.gameObject.CompareTag(goal)) playerScore ();
	}
	void playerScore()
	{
		transform.localPosition = new Vector3 (-254.5f, -95.12941f, 0.0f);
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		Invoke("restartBall", 2.0f);
	}
	void restartBall() {
		int randSign = Random.Range (0, 2) * 2 - 1;
		GetComponent<Rigidbody> ().AddForce (randSign*restartForce);
	}
}