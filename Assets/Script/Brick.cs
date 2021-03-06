﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    public AudioClip tickSound;
    public static int brickCounter;
    public LevelManager lvlManager;
    public Sprite[] hitSprites;
    public static int breakableCount=0;
    public GameObject smoke;
    public GameObject XLife,XLong, SlowDown;
    public Sprite[] bonus;
    public  bool isEnabled = true;
    

     int hitCounter;
     int maxHit;
     bool isBreakable;
     
    

    private bool flag = false;
    private float timerOfLength = 0;
    // Use this for initialization
    void Start () {
        
        
        isBreakable = (this.tag == "breakable");
        //keep track of the breakable bricks
        if (isBreakable)
        {
            
            breakableCount++;
        }
        hitCounter = 0;
        lvlManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isEnabled == true)
        {
            AudioSource.PlayClipAtPoint(tickSound, transform.position);

            if (isBreakable)
            {
                handleHits();
            }
        }
        else
        {
            //do nothing
        }
    }

    //Hit counter
    void handleHits()
    {
       
            maxHit = hitSprites.Length + 1;
            hitCounter++;

            if (hitCounter >= maxHit)
            {

                // = Quaternion.identity;
                brickDestroyedEvent();
            }
            else
                loadSprites();
        
    }

    //Destroyed bricks load up
    void loadSprites()
    {
        int spriteIndex = (hitCounter - 1);

        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
            Debug.LogError("Sprite at index " + spriteIndex + " is missing")    ;
    }

    //Brick destroyed 
    void brickDestroyedEvent()
    {
        //TODO Call bonus spawn on destroying a brick if chance is higher than lvlManager.chance
        breakableCount--;
        
        GameObject smokePuff = (GameObject)Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
        Destroy(gameObject);
        bonusSpawn();
        lvlManager.BrickDestroyed();

    }

    //Chance upon which spawn will be spawned.
    void bonusSpawn()
    {
        double willSpawn = Random.value;
        //Debug.Log(willSpawn);

        if(willSpawn > (1- LevelManager.chance))
        {
           // Debug.Log("willSpawn was greater");
            double bonusToSpawn = Random.value;

            if (bonusToSpawn > .85)
            {
                createSpawn(XLife);
                return;
            }
            else if (bonusToSpawn > .50)
            {
                createSpawn(XLong);
                return; 
            }
            else
                createSpawn(SlowDown);
            return;
 
        }
    }

    //Creates Spawn on brick destroy
    void createSpawn(GameObject nameOfSpawn)
    {
        //TODO Create game object and add velocity + on trigger when contact the paddle
        GameObject whatToSpawn = (GameObject)Instantiate(nameOfSpawn, gameObject.transform.position, Quaternion.identity);
        whatToSpawn.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -2f);
    }

    

   public void setEnabled(bool x)
    {
        isEnabled = x;
    }



}

