using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
    public bool testing = false;
    private paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBall;

    public static bool noBanana = true;
    public static char kindOfFlag;
    public int duration;
    public int timeRemaining;
    public bool isCountingDown = false;

    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<paddle>();
        paddleToBall = this.transform.position - paddle.transform.position;
        //print(paddleToBall);
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBall;
            if (Input.GetMouseButtonDown(0))
            {

                if(testing == true)
                {
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(.5f, 12);
                    hasStarted = true;
                }
                if (kindOfFlag == 'e')
                {
                    easyStart(8f);
                    hasStarted = true;
                }
                if (kindOfFlag == 'm')
                {
                    easyStart(12f);
                    hasStarted = true;
                }
                if (kindOfFlag == 'h')
                {
                    easyStart(16f);
                    hasStarted = true;
                }
                if (kindOfFlag == 'y')
                {
                    easyStart(18f);
                    hasStarted = true;
                }

            }
            
        }


    }   

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, .2f),Random.Range(0f, .2f));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
           
        }
    }
    void FixedUpdate()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude > 20f)
        {
            this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * 20f;
        }
    }

    void easyStart(float i)
    {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(.5f, i);
            hasStarted = true;
        
    }

    public void setTimer(int i)
    {
        duration = i;
        Begin();
    }

    public void Begin()
    {
        if (!isCountingDown)
        {

            isCountingDown = true;
            timeRemaining = duration;
            Invoke("tick", 1f);
        }
    }

    private void tick()
    {
        
        timeRemaining--;
        if (timeRemaining > 0)
        {
            Invoke("tick", 1f);
        }
        else
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("breakable");
            foreach (GameObject obj in objects)
            {
                obj.GetComponent<Brick>().setEnabled(true);
                obj.GetComponent<Brick>().enabled = true;
            }
            isCountingDown = false;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 200, 100, 100), "Your % chance for this level is " + (LevelManager.chance * 100));
    }

}
