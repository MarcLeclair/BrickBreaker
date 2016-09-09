using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

    
    public LevelManager lvlManager;
	void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log("stuck here");
        Debug.Log("life is " + GameObject.FindGameObjectWithTag("lvlManager").GetComponent<LevelManager>().getLife());
        if (GameObject.FindGameObjectWithTag("lvlManager").GetComponent<LevelManager>().getLife() <= 0)
        {
            Debug.Log("lmao you're here");
            lvlManager = GameObject.FindObjectOfType<LevelManager>();
            lvlManager.LoadLevel("Lose");
        }
        else
        {
            Debug.Log("restarted");
            Destroy(GameObject.FindGameObjectWithTag("life"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameObject.FindGameObjectWithTag("lvlManager").GetComponent<LevelManager>().setLife(1, '-');
            Debug.Log("life is now " + GameObject.FindGameObjectWithTag("lvlManager").GetComponent<LevelManager>().getLife());
        }
    }
   
}
