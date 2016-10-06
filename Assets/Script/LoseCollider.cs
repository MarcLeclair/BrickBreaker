using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    static bool isSet = false;
    private static int life;
    public LevelManager lvlManager;
    public Sprite[] lifeSprites;

    void Awake()
    {
        if (isSet == false)
        {
            setLife(0, 'r');
            
        }
    }
	void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log("ball hit me");
        if(life <= 0 )
        {
            
            lvlManager = GameObject.FindObjectOfType<LevelManager>();
            GameObject.FindGameObjectWithTag("life").GetComponent<LifeManager>().resetLife();
            lvlManager.LoadLevel("Lose");
            isSet = false;
        }else
        {

            setLife(1, '-');
            Brick.breakableCount = 0;
            GameObject.FindGameObjectWithTag("life").GetComponent<LifeManager>().loadSprites("down");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
     
    }

    public void setLife(int x, char opp)
    {

        if (string.Equals(opp, '+'))
        {
            life += x;
            isSet = true;
        }else if (string.Equals(opp, '-'))
        {
            
            life -= x;
            isSet = true;
    
        }else if (string.Equals(opp, 'r'))
        {
            life = 2;
            isSet = false;
        }else
            Debug.LogError("wrong opperand");
    }


    public int getLife()
    {
        return life;
    }
}
