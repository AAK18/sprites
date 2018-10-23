using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float healthed, damage;
    bool hehide;
    bool ispress = false;

	void Start ()
    {
       
        damage = 1000;
	}
	
	
	void Update ()
    {
        if (Input.GetKeyDown("p")) { ispress = true; }
        else if (Input.GetKeyDown("o")) { ispress = false;}

		if(ispress)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(-5, 0, 0);
        }
        else if (!ispress) { gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0); }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player" && hehide == false)
        {
            hehide = other.gameObject.GetComponent<Health>().thishide;
            healthed = other.gameObject.GetComponent<Health>().fhealth;
            other.gameObject.GetComponent<Health>().fhealth = healthed - damage;
        }
    }


}

