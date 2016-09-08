using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private float time;
    public static float chance;
    public int life;

    public void LoadLevel(string name)
    {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
        setLife();
        Debug.Log(life);

    }
    public void QuitGame()  
    {
        Application.Quit();
    }
    public void ReturnToStart()
    {
        Brick.breakableCount = 0;
        SceneManager.LoadScene("Start");
    }
    public void LoadNextLevel()
    {
        //TODO fix calculate so it occurs on the right level call
        time = Time.timeSinceLevelLoad;
        setLife();
        calculateChancePercentage();
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void BrickDestroyed()    
    {
        if (Brick.breakableCount <=0)
        {
            LoadNextLevel();
        }
    }

    public void calculateChancePercentage()
    {
        float timeLimit = (SceneManager.GetActiveScene().buildIndex - 1) * 15 ;
        Debug.Log("timeLimit is " + timeLimit);
        if (time < 30 + timeLimit)
        {
           
            chance = (float) 4 / 4;
           
            return;
        }
        if(time < 45 + timeLimit )
        {
            chance = (float)2 / 4;
            return;
        }
        if(time < 60 + timeLimit)
        {
            chance = (float)1 / 4;
            return;
        }
        if(time < 90 + timeLimit)
        {
            chance = (float)1 / 5;
            return;
        }
        if(time < 120 + timeLimit)
        {
            chance = (float) 1 / 6;
            return;
        }
    }

    public int getLife()
    {
        return life;
    }

    private void setLife()
    {
        life = 3;
    }
    
}

