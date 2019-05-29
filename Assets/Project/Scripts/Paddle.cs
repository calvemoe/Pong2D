using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField]
    private float speed = 1f;

    //player index for control
    [SerializeField]
    private int playerIndex = 1;

    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

        float vAxis = Input.GetAxis("Vertical" + playerIndex);
        rb.velocity = new Vector2(0, vAxis * speed);

    }
}
