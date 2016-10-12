using UnityEngine;
using System.Collections;

public class tornado : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float x = GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody2D>().velocity.x;
        float y = GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody2D>().velocity.y;

        GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody2D>().velocity = new Vector2(-x, -y);
    }
	
}
