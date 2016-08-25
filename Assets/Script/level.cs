using UnityEngine;
using System.Collections;

public class level : MonoBehaviour {
    private LevelManager lvlManager;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	        if(this.transform.childCount == 0)
        {
            lvlManager = GameObject.FindObjectOfType<LevelManager>();
            lvlManager.LoadLevel("Level_02");
        }
	}
}
