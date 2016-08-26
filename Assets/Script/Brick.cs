using UnityEngine;
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
    public SpriteOfBonus[] bonus;

    private int hitCounter;
    private int maxHit;
    private bool isBreakable;

    public object Quanternion { get; private set; }

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
        AudioSource.PlayClipAtPoint(tickSound, transform.position);
       
        if (isBreakable)
        {
            handleHits();
        }
    }
    void handleHits()
    {

        maxHit = hitSprites.Length + 1;
        hitCounter++;

        if (hitCounter >= maxHit)
        {

            // = Quaternion.identity;
            brickDestroyedEven();
        }
        else
            loadSprites();
    }
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
    void brickDestroyedEvent()
    {
        //TODO Call bonus spawn on destroying a brick if chance is higher than lvlManager.chance
        breakableCount--;
        GameObject smokePuff = (GameObject)Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
        Destroy(gameObject);
        lvlManager.BrickDestroyed();
    }
    void bonusSpawn()
    {
        double willSpawn = Random.value;

        if(willSpawn > LevelManager.chance)
        {
            double bonusToSpawn = Random.value;

            if (bonusToSpawn > .85)
            {
                createSpawn("life");
                break;
            }
            else if (bonusToSpawn > .50)
            {
                createSpawn("longer");
                break;
            }
            else
                createSpawn("slow");
 
        }
    }

    void createSpawn(string nameOfSpawn)
    {
        //TODO Create game object and add velocity + on trigger when contact the paddle
        GameObject whatToSpawn = (GameObject)Instantiate(spawn, gameObject.transform.position, Quaternion.identity);
        whatToSpawn.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
}
