using UnityEngine;
using System.Collections;

public class RainScript : MonoBehaviour {

    public GameObject ball;
    public paddle paddle;
    public Sprite[] RainSprites;
    public string nameOfSpawn;
    public AudioClip ballEntering, popping;

     bool hasStarted = false;
     float timeRemaining;
     float x, y;
   
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-x, -y);
      
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            AudioSource.PlayClipAtPoint(ballEntering, transform.position);
            GameObject.FindGameObjectWithTag("ceiling").GetComponent<ScrewThePlayerSpawn>().setRain(true);
            triggeredEffect();
            // Debug.Log("Right here");
           

        }
    }

    void triggeredEffect()
    {
        this.GetComponent<SpriteRenderer>().sprite = RainSprites[1];
        Destroy(GameObject.FindGameObjectWithTag("ball"));
        this.GetComponent<Rigidbody2D>().gravityScale = 0.8f;
         x = getNewDirection(0f, -6f, 7f);
         y = Random.Range(1f, 7f);
        this.GetComponent<Rigidbody2D>().isKinematic = false;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
        this.GetComponent<BoxCollider2D>().isTrigger = false;
        disableBricks();
        Begin();
    }

    public void Begin()
    {
        if (!hasStarted)
        {

            hasStarted = true;
            timeRemaining = 2f;
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
            hasStarted = false;
            AudioSource.PlayClipAtPoint(popping, transform.position);
            createBall();
            enableBricks();
            Destroy(gameObject);
        }
    }

    void createBall()
    {
        Vector2 pos = this.transform.position;  
        GameObject ballSpawned = (GameObject)Instantiate(ball, pos, Quaternion.identity);
         x = getNewDirection(0f, -12f, 10f);
         y = getNewDirection(0f, -12f, -5f);
        ballSpawned.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
        GameObject.FindGameObjectWithTag("ceiling").GetComponent<ScrewThePlayerSpawn>().setRain(false);
        GameObject.FindGameObjectWithTag("ball").GetComponent<ball>().setStarting(true);
    }

    void disableBricks()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("breakable");
        foreach (GameObject obj in objects)
        {

            obj.GetComponent<BoxCollider2D>().isTrigger = true;
            
        }
        objects = GameObject.FindGameObjectsWithTag("Unbreakable");
        foreach (GameObject obj in objects)
        {

            obj.GetComponent<BoxCollider2D>().isTrigger = true;

        }
    }

    void enableBricks()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("breakable");
        foreach (GameObject obj in objects)
        {

            obj.GetComponent<BoxCollider2D>().isTrigger = false;

        }
        objects = GameObject.FindGameObjectsWithTag("Unbreakable");
        foreach (GameObject obj in objects)
        {

            obj.GetComponent<BoxCollider2D>().isTrigger = false;

        }
    }

    float getNewDirection(float x, float floor, float ceiling)
    {
        float random = Random.Range(floor, ceiling);

        while(random == x)
        {
            random = Random.Range(floor, ceiling);
        }

        return random;
        
    }
}

