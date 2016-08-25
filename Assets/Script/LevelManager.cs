using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
   
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
}

