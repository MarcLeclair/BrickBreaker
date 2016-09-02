using UnityEngine;
using System.Collections;

public class RandomSpawns : MonoBehaviour {
    public paddle paddle;
    public LoseCollider loseCollider;
    public ball ball;
    public Brick brick;

    public string nameOfSpawn;
 
    void Update()
    {

        //Finds object with Spawn tag and if lower than paddle y pos, means that player missed the spawn -->destroy to not reset the game
        
        if (GameObject.FindGameObjectsWithTag("Spawn") != null)
        {

            if (this.transform.position.y < paddle.transform.position.y)
            {
                Destroy(gameObject);

            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "paddle")
        {
            triggeredEffect();
            Debug.Log("Right here");
            Destroy(this.gameObject);
           
        }
    }

    void triggeredEffect()
    {
        if (string.Equals(nameOfSpawn, "slowdown"))
            {
            Debug.Log("position " + ball.transform.position);
            ball.whatis();
            Debug.Log("current velocity " + ball.GetComponent<Rigidbody2D>().velocity);
            Vector2 velocity = ball.GetComponent<Rigidbody2D>().velocity;
            ball.GetComponent<Rigidbody2D>().velocity = velocity * 0.5f;
            Debug.Log("slowdown: new velocity" + ball.GetComponent<Rigidbody2D>().velocity);
        }
    }
    
}
