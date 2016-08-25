using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager lvlManager;
	void OnTriggerEnter2D (Collider2D collision)
    {
        lvlManager= GameObject.FindObjectOfType<LevelManager>();
        lvlManager.LoadLevel("Lose");
       
    }
    void OnCollisionEnter2D (Collision2D collision)
    {
        print("Collision");
    }
}
