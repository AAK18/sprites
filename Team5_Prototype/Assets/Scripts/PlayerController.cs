 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed, sideMovement = 0.0f;
    private Rigidbody2D control;
    public float jumpforce;
    bool ground;
    bool faceRight = true;
    public Animator animate;

    void Start()
    {
        control = GetComponent<Rigidbody2D>();
        speed = 5;
        
    }

    

    void Update()
    {
        Movement();
       
    }

    void Movement()
    {
        sideMovement = Input.GetAxis("Horizontal") * speed;
        if (sideMovement == 0) { animate.SetBool("KeyDown", false); }
        else { animate.SetBool("KeyDown", true); }

        control.velocity = new Vector2(sideMovement, control.velocity.y);
        
            Jump();
        animate.SetFloat("Speed", Mathf.Abs(sideMovement));

        if (sideMovement < 0 && faceRight == true)
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

