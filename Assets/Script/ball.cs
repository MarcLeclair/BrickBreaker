using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
    private paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBall;

    public static char kindOfFlag;

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
                if (kindOfFlag == 'e')
                {
                    easyStart(8f);
                }
                if (kindOfFlag == 'm')
                {
                    easyStart(12f);
                }
                if (kindOfFlag == 'h')
                {
                    easyStart(16f);
                }
                if (kindOfFlag == 'y')
                {
                    easyStart(18f);
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

   

}
