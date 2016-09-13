using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {
    private int currentIndex = 0;
    public Sprite[] lifeSprites;
    static LifeManager instance = null;
    // Use this for initialization

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Destryoing" + instance);
            Destroy(gameObject);

        }
        else
        {
            Debug.Log(instance);
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }

    }

       public void loadSprites(string life)
    {
        if (string.Equals(life, "up"))
        {
            if(currentIndex > 3)
            {
                //Do nothing
            }
            else if(currentIndex < 3){
                this.GetComponent<SpriteRenderer>().sprite = lifeSprites[currentIndex - 1];
            }
        }
        if (string.Equals(life, "down"))
        {

            if (currentIndex < 0)
            {
                //Do nothing
            }
            else if (currentIndex > 0)
            {
                this.GetComponent<SpriteRenderer>().sprite = lifeSprites[currentIndex + 1];
            }
        }
    }
    public int getIndex()
    {
        return currentIndex;
    }
}

