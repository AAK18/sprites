using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {

    public GameObject player;
    bool collected = false;
    float xs, ys;
	
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");	
	}

    void Update()
    {
        // xs = player.transform.position.x + 0.277;
        //ys = player.transform.position.y + 0.062;
        if (collected == true)
        {

            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
            if (player.transform.localScale.x > 0)
            {
                Vector3 temp = gameObject.transform.position;
                temp.x = player.transform.position.x + 0.277f;
                temp.y = player.transform.position.y - 0.068f;
                gameObject.transform.position = temp;

                if (gameObject.transform.localScale.x > 0)
                {
                    Vector2 temp2 = gameObject.transform.localScale;
                    temp2.x *= -1;
                    gameObject.transform.localScale = temp2;
                }
            }
            else if (player.transform.localScale.x < 0)
            {
                Vector3 temp = gameObject.transform.position;
                temp.x = player.transform.position.x - 0.343f;
                temp.y = player.transform.position.y - 0.068f;
                gameObject.transform.position = temp;

                if (gameObject.transform.localScale.x < 0)
                {
                    Vector2 temp2 = gameObject.transform.localScale;
                    temp2.x *= -1;
                    gameObject.transform.localScale = temp2;
                }

            }
        }
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
         if (other.gameObject.CompareTag("Player"))
         {
                gameObject.transform.position = other.transform.position;
                collected = true;
        }
    }
    
}
