using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    /*https://youtu.be/J6FfcJpbPXE*/
    public static GameController control;

    private Vector3 ballPosition = new Vector3(0, 0, 0);
    private Vector3 ballVelocity = new Vector3(0, 0, 0);
    private Vector3 paddle1Position = new Vector3(0, 0, 0);
    private Vector3 paddle2Position = new Vector3(0, 0, 0);
    private GameObject ball;
    private GameObject paddle1;
    private GameObject paddle2;
    private bool AIactive = false;
    private int p1score = 0;
    private int p2score = 0;
    public bool canLoad = false;
	// Use this for initialization
	void Awake () {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        } 
        else if(control != this)
        {
            Destroy(gameObject);
        }
	}

    private void Update()
    { /*crappy hack solution maybe, saves state on pause*/
        if(Input.GetKeyDown(KeyCode.P))
        {
            ball = GameObject.FindGameObjectsWithTag("ball")[0];
            paddle1 = GameObject.FindGameObjectsWithTag("paddle")[0];
            paddle2 = GameObject.FindGameObjectsWithTag("paddle")[1];       
            ballPosition = ball.transform.position;
            ballVelocity = ball.GetComponent<Rigidbody>().velocity;
            paddle1Position = paddle1.transform.position;
            paddle2Position = paddle2.transform.position;
            p1score = ball.GetComponent<BallWinState>().leftScore;
            p2score = ball.GetComponent<BallWinState>().rightScore;
            AIactive = paddle2.GetComponent<AI>().enabled;
            canLoad = true;
        }
    }

    public void Load()
    {
        /*Load status of the ball*/
        GameObject ball = GameObject.FindGameObjectWithTag("ball");
        ball.transform.position = ballPosition;
        ball.GetComponent<Rigidbody>().velocity = ballVelocity;
        /*Load score status*/
        BallWinState ballStatus = ball.GetComponent<BallWinState>();
        ballStatus.leftScore = p1score;
        ballStatus.rightScore = p2score;
        ballStatus.leftText.text = p1score.ToString();
        ballStatus.rightText.text = p2score.ToString();
        /*Load paddle states*/
        GameObject[] paddles = GameObject.FindGameObjectsWithTag("paddle");
        paddles[0].transform.position = paddle1Position;
        paddles[1].transform.position = paddle2Position;
        /*Load AI state*/
        GameObject enemy = GameObject.FindGameObjectsWithTag("paddle")[1];
        if (!AIactive)
        {
            enemy.GetComponent<AI>().enabled = false;
            enemy.GetComponent<PaddleMovement>().enabled = true;
        }
        canLoad = false;
        Time.timeScale = 1;
    }
}
