using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScrewThePlayerSpawn : MonoBehaviour {

    public GameObject spawnForLevel;
	
	public bool countDown,hasSpawned = false;
    public float timeRemaining, paddleTime;
    public paddle paddle;
    public Sprite[] rainSprites;
    private bool ballIsInRainDrop = false;
 

    void Update () {
      
            if (!hasSpawned && !ballIsInRainDrop)
            {
                createSpawn();
            }

            if (!GameObject.FindGameObjectWithTag("paddle").GetComponent<paddle>().enabled)
            {
                paddleParalyzedTimer();
            }
        

    }
  
    public void setRain(bool x)
    {
        ballIsInRainDrop = x;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "paddle")
        {

            Destroy(this.gameObject);
        }
    }
    private void createSpawn()
    {
        double willSpawn = Random.value;

        if (Time.timeSinceLevelLoad > ( SceneManager.GetActiveScene().buildIndex * 5))
        {
            double chanceOfBadSpawn = .5;
            if (Time.timeSinceLevelLoad > (10f + SceneManager.GetActiveScene().buildIndex * 5))
            {
                chanceOfBadSpawn = .4;
            }
            else if (Time.timeSinceLevelLoad > (15f + SceneManager.GetActiveScene().buildIndex * 5))
            {
                chanceOfBadSpawn = .3;
            }
            else if (Time.timeSinceLevelLoad > (22f + SceneManager.GetActiveScene().buildIndex * 5))
            {
                chanceOfBadSpawn = .2;
            }
            else if (Time.timeSinceLevelLoad > (30f + SceneManager.GetActiveScene().buildIndex * 5))
            {
                chanceOfBadSpawn = .1;
            }
            
            if (willSpawn > chanceOfBadSpawn)
            {
               
                if (spawnForLevel.name != "tornado")
                {
                    Debug.Log("creating spawn");
                    float x = GameObject.FindGameObjectWithTag("ceiling").GetComponent<Collider2D>().bounds.size.x;
                    Vector2 pos = new Vector2(Random.Range(0, x), GameObject.FindGameObjectWithTag("ceiling").transform.position.y);
                    GameObject whatToSpawn = (GameObject)Instantiate(spawnForLevel, pos, Quaternion.identity);
                    whatToSpawn.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -2f);
                    Begin();
                }

                else
                {
                    Debug.Log("creating spawn");
                    float x = GameObject.FindGameObjectWithTag("ceiling").GetComponent<Collider2D>().bounds.size.x;
                    Vector2 pos = new Vector2(Random.Range(0, x), GameObject.FindGameObjectWithTag("ceiling").transform.position.y);
                    GameObject whatToSpawn = (GameObject)Instantiate(spawnForLevel, pos, Quaternion.identity);
                    Begin();
                }
            }
        }
        
    }

    public void Begin()
    {
        if (!hasSpawned)
        {
            float time = 9;
            if (Time.timeSinceLevelLoad > (40f + SceneManager.GetActiveScene().buildIndex * 5))
            {
                time = 7;
            }
            else if (Time.timeSinceLevelLoad > (50f + SceneManager.GetActiveScene().buildIndex * 5))
            {
                time = 5;
            }
            else if (Time.timeSinceLevelLoad > (50f + SceneManager.GetActiveScene().buildIndex * 5))
            {
                time = 4;
            }
            else if (Time.timeSinceLevelLoad > (50f + SceneManager.GetActiveScene().buildIndex * 5))
            {
                time = 3;
            }

            hasSpawned = true;
            timeRemaining = time;
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
            hasSpawned = false;
        }
    }

    void paddleParalyzedTimer()
    {
        if (!countDown)
        {
            countDown = true;
            paddleTime = 1f;
            Invoke("paddleTick", 1f);
        }
    }

    void paddleTick()
    {

        paddleTime--;
        if (paddleTime > 0)
        {
            Invoke("paddleTick", 1f);
        }
        else
        {
            GameObject.FindGameObjectWithTag("paddle").GetComponent<paddle>().enabled = true;

        }
    }
}
