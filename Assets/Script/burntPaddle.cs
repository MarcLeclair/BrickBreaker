using UnityEngine;
using System.Collections;

public class burntPaddle : MonoBehaviour {

     bool isCountingDown = false;
     float timeRemaining;

    public GameObject paddle;
	// Use this for initialization
	void Awake () {
        setTimer(10);
	}
	
	// Update is called once per frame
	void Update () {
        MoveWithMouse();
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
        timeRemaining = i;
        Begin();
    }

    //Countdown if the paddle has been increased. using Invoke() for repetition and seconds.
    public void Begin()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            Invoke("_tick", 1f);
        }
    }


    private void _tick()
    {
      
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("_tick", 1f);
        }
        else
        {
            Vector2 pos = this.GetComponent<Transform>().transform.position;
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("ball").GetComponent<ball>().setPaddle(false);
          GameObject newPaddle = (GameObject)Instantiate(paddle, pos, Quaternion.identity);
        }
    }

}
