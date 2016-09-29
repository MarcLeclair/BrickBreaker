using UnityEngine;
using System.Collections;

public class paddle : MonoBehaviour {
    public bool autoPlay = false;

    private ball ball;

    public int duration;
    public int timeRemaining;
    public bool isCountingDown = false;
    public bool showText = false;

    void Start()
    {
        ball = GameObject.FindObjectOfType<ball>();
    }
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
            AutoPlay();
	}
    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(.5f, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, .5f, 15.5f);
        this.transform.position = paddlePos;
    }
    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(.5f, this.transform.position.y, 0f);
        float positn = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(positn, .5f, 15.5f);
        this.transform.position = paddlePos;
    }

    //Sets countDown timer
    public void setTimer(int i)
    {
        duration = i;
        Begin();
    }

    //Countdown if the paddle has been increased. using Invoke() for repetition and seconds.
    public void Begin()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("_tick", 1f);
        }
    }


    private void _tick()
    {
        if (timeRemaining == 5f)
        {
            showText = true;
        }
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("_tick", 1f);
        }
        else
        {
            GameObject.FindGameObjectWithTag("paddle").GetComponent<Transform>().localScale += new Vector3(-0.5F, 0, 0);
            isCountingDown = false;
            showText = false;
        }
    }

    void OnGUI()
    {
        if (showText)
        {
            GUI.Label(new Rect(0, 0, 100, 100), "Bar will go back to normal size in " + timeRemaining + " seconds" );
        }
    }
}
