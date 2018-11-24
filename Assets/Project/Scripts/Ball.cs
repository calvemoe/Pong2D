using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //increase ball speed after bouncing the paddle
    public float speedMultiplier = 1.33f;

    //speeds for h Axis
    public float minXSpeed = 0.8f; 
    public float maxXSpeed = 1.2f;

    //speeds for v Axis
    public float minYSpeed = 0.8f; 
    public float maxYSpeed = 1.2f; 

    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

        //apply speed to ball
        rb.velocity = new Vector2(
            Random.Range(minXSpeed, maxXSpeed) * Random.value > 0.5f ? -1 : 1, 
            Random.Range(minYSpeed, maxYSpeed) * Random.value > 0.5f ? -1 : 1
        );
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //bouncing ball
        if(other.CompareTag("Limit"))
        {
            GetComponent<AudioSource>().Play();

            //top gamefield limit
            if (other.transform.position.y > transform.position.y && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }
            //bottom gamefield limit
            if (other.transform.position.y < transform.position.y && rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }
        }
        else if (other.CompareTag("Paddle"))
        {
            GetComponent<AudioSource>().Play();

            //left paddle
            if (other.transform.position.x < transform.position.x && rb.velocity.x < 0)
            {
                rb.velocity = new Vector2(
                    -rb.velocity.x * speedMultiplier, 
                    rb.velocity.y * speedMultiplier
                );
            }
            //right paddle
            if (other.transform.position.x > transform.position.x && rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(
                    -rb.velocity.x * speedMultiplier, 
                    rb.velocity.y * speedMultiplier
                );
            }
        }

    }
}
