using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    
    public LevelManager lvlManager;
	void OnTriggerEnter2D (Collider2D collision)
    {
        
        if (lvlManager.getLife() <= 0)
        {
            lvlManager = GameObject.FindObjectOfType<LevelManager>();
            lvlManager.LoadLevel("Lose");
        }
        else
        {
            Destroy(GameObject.FindGameObjectWithTag("life"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
   
}
