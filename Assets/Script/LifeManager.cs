using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {
    private  static int  currentIndex = 0;
    public Sprite[] lifeSprites;
    static LifeManager instance = null;
    // Use this for initialization

    void Awake()
    {
        this.GetComponent<SpriteRenderer>().sprite = lifeSprites[currentIndex];

    }


    public void loadSprites(string life)
    {

        if (string.Equals(life, "down"))
        {
            if(currentIndex > 2)
            {
                //Do nothing
            }else if(currentIndex < 2){
            
                currentIndex += 1;
                this.GetComponent<SpriteRenderer>().sprite = lifeSprites[currentIndex];
                
            }
        }

        if (string.Equals(life, "up"))
        {

            if (currentIndex < 0)
            {
                //Do nothing
            }else if (currentIndex > 0)
            {
                currentIndex -= 1;
                this.GetComponent<SpriteRenderer>().sprite = lifeSprites[currentIndex];
              
            }
        }
    }

    public int getIndex()
    {
        return currentIndex;
    }

    public void resetLife()
    {
        currentIndex = 0;  
    }
    void OnGUI()
    {

        int time = (int)Time.timeSinceLevelLoad;
        GUI.Label(new Rect(0, 50, 100, 100), " " + time + "s");
    }

}

