using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

   
    public float fhealth;
    float damaged;
    public GameObject player;
    public GameObject[] list;
   public bool inZone, isAlive;
    public SpriteRenderer temp;
    public bool thishide = false;
    

	void Start ()
    {

        thishide = gameObject.GetComponent<PlayerController>().isHiding;
        fhealth = 100;
        isAlive = true;
	}
	
	
	void Update ()
    {
        if (isAlive)
        {
            thishide = gameObject.GetComponent<PlayerController>().isHiding;
            if (fhealth <= 0)
            {
                isAlive = false;
                gameObject.transform.Rotate(0, 0, 90);
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            }
        }
        else if(!isAlive)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            list = GameObject.FindGameObjectsWithTag("Death");
            list[0].SetActive(true);
            list[1].SetActive(true);
            if(Input.GetKeyDown("r"))
            {
                respawn();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    void respawn()
    {

    }
}
