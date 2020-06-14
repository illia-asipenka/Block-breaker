using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float y1 = 0f;
    private float y2 = 0f;
    private float deltaY;
    private float stucktime;
    private float timer;
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
    private bool nowPlaying = false;
    private static Vector3 startBallPos;
    private static Vector3 startPaddlePos;

    // Start is called before the first frame update
    void Start()
    {
        startBallPos = transform.position;
        PlaceTheBallToStartPosition();
    }

    // Update is called once per frame
    void Update()
    {
        StuckCheck();

        GetReadyToStart();

        StartPlaying();

    }
    
    public void PlaceTheBallToStartPosition()
    {
        nowPlaying = false;
        paddle = GameObject.FindObjectOfType<Paddle>();
        startPaddlePos = paddle.transform.position;
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }


    public void GetReadyToStart()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;
        }
    }

    public void StartPlaying()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            Debug.Log("Now launching the ball");

            if (this.TryGetComponent<Rigidbody2D>(out Rigidbody2D myBody) && !nowPlaying)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                nowPlaying = true;
                //myBody.velocity = new Vector2(2f, 10f);
            }

        }
    }

    public void StuckCheck()
    {
        timer += Time.deltaTime;

        if (Time.frameCount >= 2)
        {
            y2 = y1;
            y1 = this.transform.position.y;
            deltaY = y2 - y1;
            if (deltaY < 0.01)
            {
                stucktime += Time.deltaTime;
                if (stucktime >= 10)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
                    stucktime = 0;
                }
            }
            else
            {
                stucktime = 0;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasStarted)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        hasStarted = false;
        if (LevelManager.playerLives >= 0)
        {
            paddle.transform.position = startPaddlePos;
            this.transform.position = startBallPos;
            PlaceTheBallToStartPosition();
        }
        
    }


}
