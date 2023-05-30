using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpingPower = 400f;
    bool rightPressed = false;
    bool leftPressed = false;

    public GameObject player;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
    }
    void Update()
    {


        if (rightPressed)
        {

            transform.Translate(Vector2.right * speed * Time.deltaTime);
            player.transform.localScale = new Vector2(-2.035237f, 1.875094f);
        }
        if (leftPressed)
        {

            transform.Translate(Vector2.right * -1 * speed * Time.deltaTime);
            player.transform.localScale = new Vector2(2.035237f, 1.875094f);
        }

        //movement
        /* float horizontal = Input.GetAxisRaw("Horizontal");
         transform.Translate(Vector2.right*horizontal*speed*Time.deltaTime);
         if(horizontal != 0)
         {
             if(horizontal < 0)
             {
             player.transform.localScale = new Vector2(-2.035237f, 1.875094f);
             }
             if(horizontal > 0)
             {
                player.transform.localScale = new Vector2(2.035237f, 1.875094f);
             }
             //we can set running animation to True over here
         }
         else if(horizontal == 0 || IsGrounded() == false)
         {
             //set running animation to false 
             //set jump animation to true
         }


         if (Input.GetButtonDown("Jump") && IsGrounded())
         {
             rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
         }

         if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
         {
             rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
         }*/


    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }
    public void MoveRight()
    {
        rightPressed = true;
        leftPressed = false;
    }

    public void MoveLeft()
    {
        leftPressed = true;
        rightPressed = false;
    }

    public void ButtonUp()
    {
        rightPressed = false;
        leftPressed = false;
    }

    public void Jump()
    {
        if (IsGrounded())
        {

            rb.AddForce(Vector2.up * jumpingPower);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
