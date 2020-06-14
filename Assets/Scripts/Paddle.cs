using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float mousePosInBlocks;
    Vector3 paddlePos;
    public bool autoPlay = false;
    private Ball ball;
    float paddleSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        paddlePos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!autoPlay)
        {
            MoveWithArrows();
            //MoveWithMouse();

        }
        else
        {
            AutoPlay();
        }


    }

    private void AutoPlay()
    {
        Vector3 ballPos = ball.transform.position;
        paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        paddlePos.x = Mathf.Clamp(ballPos.x, 1f, 15f);

        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);

        this.transform.position = paddlePos;
    }

    void MoveWithArrows()
    {  

        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            paddlePos += Vector3.left * paddleSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            paddlePos += Vector3.right * paddleSpeed * Time.deltaTime; 
        }

        

        paddlePos.x = Mathf.Clamp(paddlePos.x, 1f, 15f);

        this.transform.position = paddlePos;
    }
}
