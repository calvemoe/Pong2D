using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContoller : MonoBehaviour {

    //Score labels
    public Text Score1Text;
    public Text Score2Text;

    //coordinates out of the screen
    public float scoreCoordianates = 3.3f;

    //for ball instance
    public GameObject ballPrefab;

    private Ball currentBall;

    //Score values
    private int score1 = 0;
    private int score2 = 0;

    //const
    private static int MAXSCORE = 99;

	// Use this for initialization
	void Start () {

        SpawnBall();
	}

    void SpawnBall()
    {
        //create ball in game scene
        GameObject ballInstance = Instantiate(ballPrefab, transform);

        currentBall = ballInstance.GetComponent<Ball>();
        currentBall.transform.position = Vector3.zero;

        //initiate score at game start
        Score1Text.text = score1.ToString();
        Score2Text.text = score2.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if (currentBall != null)
        {
            if (currentBall.transform.position.x > scoreCoordianates)
            {
                //scoring for player 1
                score1++;
                if (score1 > MAXSCORE)
                    score1 = 0;
                
                //destroy ball after scoring
                Destroy(currentBall.gameObject);
                //create new ball on game scene
                SpawnBall();
            }

            if (currentBall.transform.position.x < -scoreCoordianates)
            {
                //scoring for player 2
                score2++;
                if (score2 > MAXSCORE)
                    score2 = 0;

                //destroy ball after scoring
                Destroy(currentBall.gameObject);
                //create new ball on game scene
                SpawnBall();                
            }
        }
	}
}
