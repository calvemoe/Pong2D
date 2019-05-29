using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour {

    //Score labels
    [SerializeField]
    private Text Score1Text;
    [SerializeField]
    private Text Score2Text;

    //coordinates out of the screen
    public float scoreCoordianates = 3.3f;

    [SerializeField]
    private Ball ball;

    //Score values
    private int score1 = 0;
    private int score2 = 0;

    //const
    private static int MAXSCORE = 99;

	// Use this for initialization
	void Start () {
        //initiate score at game start
        Score1Text.text = score1.ToString();
        Score2Text.text = score2.ToString();
        
        //throw the ball
        ball.ResetBall();
	}
	
	// Update is called once per frame
	void Update () {
        if (ball.transform.position.x > scoreCoordianates) {
            //scoring for player 1
            score1++;
            if (score1 > MAXSCORE)
                score1 = 0;

            //put actual score on UI
            Score1Text.text = score1.ToString();

            //reset ball on game scene
            ball.ResetBall();
        }

        if (ball.transform.position.x < -scoreCoordianates) {
            //scoring for player 2
            score2++;
            if (score2 > MAXSCORE)
                score2 = 0;

            //put actual score on UI
            Score2Text.text = score2.ToString();

            //reset ball on game scene
            ball.ResetBall();
        }
	}
}
