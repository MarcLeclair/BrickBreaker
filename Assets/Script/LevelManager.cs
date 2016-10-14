using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

     float time;

    public static float chance;
    public ball ball;

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
        float timeLimit = SceneManager.GetActiveScene().buildIndex  * 50 ;

        if (Time.timeSinceLevelLoad <  timeLimit)
        {
           
            chance = (float) 3 / 4;
           
            return;
        }
        if(Time.timeSinceLevelLoad < 15 + timeLimit )
        {
            chance = (float)2 / 4;
            return;
        }
        if(Time.timeSinceLevelLoad < 30 + timeLimit)
        {
            chance = (float)1 / 4;
            return;
        }
        if(Time.timeSinceLevelLoad < 45+ timeLimit)
        {
            chance = (float)1 / 5;
            return;
        }
        if(Time.timeSinceLevelLoad < 60 + timeLimit)
        {
            chance = (float) 1 / 6;
            return;
        }
        
            // else  do nothing, player doesn't deserve chance!
    }

    public void easyLoadLevel(string name)
    {
        ball.kindOfFlag = 'e';
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }

    public void mediumLoadLevel(string name)
    {
        ball.kindOfFlag = 'm';
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }


    public void hardloadLevel(string name)
    {
        ball.kindOfFlag = 'h';
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }


    public void youreinsaneLoadLevel(string name)
    {
        ball.kindOfFlag = 'y';
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }

}

