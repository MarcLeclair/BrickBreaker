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
           // Debug.Log("Right here");
            Destroy(this.gameObject);
           
        }
    }

    void triggeredEffect()
    {
        if (string.Equals(nameOfSpawn, "slowdown"))
            {
            Vector2 velocity = GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody2D>().velocity;
            GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody2D>().velocity = velocity * 0.8f;
        }
        if (string.Equals(nameOfSpawn, "xlife"))
        {
            GameObject.FindGameObjectWithTag("loseCollider").GetComponent<LoseCollider>().setLife(1, '+');
            Debug.Log(GameObject.FindGameObjectWithTag("loseCollider").GetComponent<LoseCollider>().getLife());
        }
        if(string.Equals(nameOfSpawn, "xlong"))
        {
            GameObject.FindGameObjectWithTag("paddle").GetComponent<Transform>().localScale += new Vector3(0.5F, 0, 0);
            GameObject.FindGameObjectWithTag("paddle").GetComponent<paddle>().setTimer(7);
        }
        if(string.Equals(nameOfSpawn, "banana"))
        {
            Vector3 paddlePos = new Vector3(.5f, GameObject.FindGameObjectWithTag("paddle").GetComponent<Transform>().position.y, 0f);
            float positn = (Input.mousePosition.x / Screen.width * 16) + 5;
            paddlePos.x = Mathf.Clamp(positn, .5f, 15.5f);
            GameObject.FindGameObjectWithTag("paddle").GetComponent<Transform>().position = paddlePos;
        }
    }
    
}
