using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private Time time;
    public static double chance;

    public void LoadLevel(string name)
    {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);

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
        time = time.timeSinceLoadLevel();
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
        Time timeLimit = (SceneManager.GetActiveScene().buildIndex - 1) * 15 ;
        if (time < 30 + timeLimit)
        {
            chance = 3 / 4;
        }
        if(time < 45 + timeLimit)
        {
            chance = 2 / 4;
        }
        if(time < 60 + timeLimit)
        {
            chance = 1 / 4;
        }
        if(time < 90 + timeLimit)
        {
            chance = 1 / 5;
        }
        if(time < 120 + timeLimit)
        {
            chance = 1 / 6;
        }
    }
    
}

