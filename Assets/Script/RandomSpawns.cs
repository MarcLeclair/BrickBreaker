using UnityEngine;
using System.Collections;

public class RandomSpawns : MonoBehaviour {

	void OnTriggerEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
