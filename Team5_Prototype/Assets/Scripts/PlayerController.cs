 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D control;
    public float jumpforce;
    bool ground;

    void Start()
    {
        control = GetComponent<Rigidbody2D>();
        speed = 5;
    }

    

    void FixedUpdate()
    {
        float sideMovement = Input.GetAxis("Horizontal");
        control.velocity = new Vector2(sideMovement * speed, control.velocity.y);
        Jump();

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            ground = false;
            control.AddForce(new Vector2(control.velocity.x, jumpforce));
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            ground = true;
            
        }
    }
}
