using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScrewThePlayerSpawn : MonoBehaviour {
    public GameObject spawnForLevel;
	// Use this for initialization
	public bool hasSpawned = false;
    public float timeRemaining;
    public paddle paddle;
    public Sprite[] rainSprites;
    private bool ballIsInRainDrop = false;
    // Update is called once per frame
    void Update () {
        if (!hasSpawned && !ballIsInRainDrop)
        {
            createSpawn();
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
            // Debug.Log("Right here");
            Destroy(this.gameObject);
        }
    }
    private void createSpawn()
    {
        double willSpawn = Random.value;
        if (Time.timeSinceLevelLoad > 1f)
        {
            //if (Time.timeSinceLevelLoad > (30f + SceneManager.GetActiveScene().buildIndex * 15))

            if (willSpawn > .1)
            {
                float x = GameObject.FindGameObjectWithTag("ceiling").GetComponent<Collider2D>().bounds.size.x;    
                Vector2 pos = new Vector2(Random.Range(0, x), GameObject.FindGameObjectWithTag("ceiling").transform.position.y);
                GameObject whatToSpawn = (GameObject)Instantiate(spawnForLevel, pos, Quaternion.identity);
                whatToSpawn.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -2f);
                Begin();   
            }
        }
    }

    public void Begin()
    {
        if (!hasSpawned)
        {

            hasSpawned = true;
            timeRemaining = 5f;
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
}
