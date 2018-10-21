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
    bool faceRight = true;

    void Start()
    {
        control = GetComponent<Rigidbody2D>();
        
    }

    

    void Update()
    {

        Movement();
    }

    void Movement()
    {
        float sideMovement = Input.GetAxis("Horizontal");
        control.velocity = new Vector2(sideMovement * speed, control.velocity.y);
        
            Jump();
        

        if(sideMovement < 0 && faceRight == true)
        {
            flip();
        }
        else if (sideMovement > 0 && faceRight == false)
        {
            flip();
        }
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

    void flip()
    {
        faceRight = !faceRight;
        Vector2 temp = gameObject.transform.localScale;
        temp.x = temp.x * -1;
        gameObject.transform.localScale = temp;
    }
}

