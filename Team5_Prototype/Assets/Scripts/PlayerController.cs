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
    public bool isHiding;
    int collisionnum = 0;
    public GameObject player;
    bool inZone = false;

    void Start()
    {
        control = GetComponent<Rigidbody2D>();
        speed = 5;
        
    }

    

    void Update()
    {
        Hiding();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hiding") && collisionnum % 2 == 1)
        {
            inZone = false;
            ++collisionnum;

        }
        else if (other.gameObject.CompareTag("Hiding") && collisionnum % 2 == 0)
        {
            inZone = true;
            ++collisionnum;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            ground = true;
            
        }
    }

    void Hiding()
    {

        if (inZone == true && isHiding == false)
        {
            if (Input.GetKeyDown("mouse 0"))
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                isHiding = true;
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                gameObject.transform.position = new Vector3(3.95f, 2.32f, 0.0f);

            }
        }
        else if (inZone == true && isHiding == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            gameObject.transform.position = new Vector3(3.95f, 2.32f, 0.0f);

            if (Input.GetKeyDown("mouse 0"))
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                isHiding = false;
            }
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

