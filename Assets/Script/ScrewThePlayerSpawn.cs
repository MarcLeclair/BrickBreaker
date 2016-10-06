using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScrewThePlayerSpawn : MonoBehaviour {
    public GameObject spawnForLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        double willSpawn = Random.value;
       if (Time.timeSinceLevelLoad > 1f)
            {
            //if (Time.timeSinceLevelLoad > (30f + SceneManager.GetActiveScene().buildIndex * 15))
            if (willSpawn > .1)
            {
                GameObject whatToSpawn = (GameObject)Instantiate(spawnForLevel, gameObject.transform.position, Quaternion.identity);
                whatToSpawn.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -2f);
            }
        }
	
	}
}
