using UnityEngine;
using System.Collections;

public class paddle : MonoBehaviour {
    public bool autoPlay = false;

    

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
}
