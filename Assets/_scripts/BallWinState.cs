using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallWinState : MonoBehaviour {

    public Text leftText;
    public Text rightText;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public GameObject winPanel;

    private string goal = "goal";
	private Vector3 restartForce = new Vector3 (5, 0, 0);
    public int leftScore, rightScore;

    private void Start()
    {
        if (PlayerPrefs.GetInt("continue") == 0)
        {
            leftText.text = "0";
            rightText.text = "0";
            leftScore = 0;
            rightScore = 0;
        }
    }

    void OnCollisionEnter(Collision ballCol)
	{
		if (ballCol.gameObject.CompareTag(goal)) playerScore ();
	}
	void playerScore()
	{
        if (transform.localPosition.x < leftPaddle.transform.localPosition.x)
        {
            rightScore += 1;
        }
        else if (transform.localPosition.x > rightPaddle.transform.localPosition.x)
        {
            leftScore += 1;
        }
        leftText.text = leftScore.ToString();
        rightText.text = rightScore.ToString();
        if (rightScore >= 10 || leftScore >= 10)
        {
            win();
            //PlayerPrefs.SetInt("continue", 0);
        }

        transform.localPosition = new Vector3 (-254.5f, -95.12941f, 0.0f);
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		Invoke("restartBall", 2.0f);
	}
	void restartBall() {
		int randSign = Random.Range (0, 2) * 2 - 1;
		GetComponent<Rigidbody> ().AddForce (randSign*restartForce);
	}

    void win()
    {
        if (leftScore > rightScore)
        {
            winPanel.GetComponentInChildren<Text>().text = "Left Side Wins!";
        }
        else
        {
            winPanel.GetComponentInChildren<Text>().text = "Right Side Wins!";
        }
        winPanel.SetActive(true);
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("game_controller").GetComponent<GameController>().canLoad = false;
    }
}