using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //increase ball speed after bouncing the paddle
    [SerializeField]
    private float speedMultiplier = 1.33f;

    //speeds for h Axis
    [SerializeField]
    private float minXSpeed = 0.8f; 
    [SerializeField]
    private float maxXSpeed = 1.2f;

    //speeds for v Axis
    [SerializeField]
    private float minYSpeed = 0.8f; 
    [SerializeField]
    private float maxYSpeed = 1.2f; 

    private Rigidbody2D rb;
    private AudioSource aus;
    private Transform tr;

    //move direction
    private static int left = -1;
    private static int right = 1;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        aus = GetComponent<AudioSource>();
        tr = transform;
    }

    // Use this for initialization
    void Start () {
        this.ResetBall();
	}

    void OnTriggerEnter2D(Collider2D other) {
        //bouncing ball
        if(other.CompareTag("Limit")) {
            aus.Play();

            //top gamefield limit
            if (other.transform.position.y > transform.position.y && rb.velocity.y > 0)
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);

            //bottom gamefield limit
            if (other.transform.position.y < transform.position.y && rb.velocity.y < 0)
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
        else if (other.CompareTag("Paddle")) {
            aus.Play();

            //left paddle
            if (other.transform.position.x < transform.position.x && rb.velocity.x < 0) 
                rb.velocity = new Vector2(
                    -rb.velocity.x * speedMultiplier, 
                    rb.velocity.y * speedMultiplier
                );

            //right paddle
            if (other.transform.position.x > transform.position.x && rb.velocity.x > 0)
                rb.velocity = new Vector2(
                    -rb.velocity.x * speedMultiplier, 
                    rb.velocity.y * speedMultiplier
                );
        }
    }

    public void ResetBall() {
        //set ball position to center
        tr.position = Vector3.zero;

        //randomize applying speed to ball in four directions
        rb.velocity = new Vector2(
            Random.Range(minXSpeed, maxXSpeed) * Random.value > 0.5f ? left : right, 
            Random.Range(minYSpeed, maxYSpeed) * Random.value > 0.5f ? left : right
        );
    }
}