using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Animator animator;
    private string currentState; //checks current state of animation

    public float speed = 1f; //speed of the player
    public float jumpingPower = 400f; //jump force
    private bool rightPressed = false;
    private bool leftPressed = false;
    private bool isAttackPressed; //bool variable to check if attack key is pressed
    private bool attacking; //bool variable to check if player is attacking or not

    public GameObject player;
    [SerializeField] private float attackDelay; //variable to dealy the animation after attack is done
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //Animation states
    const string PLAYER_IDLE = "PlayerIdle", PLAYER_ATTACK = "PlayerAttack", PLAYER_RECOVERY = "PlayerRecovery", PLAYER_COMBAT = "PlayerCombat", PLAYER_HURT = "PlayerHurt", PLAYER_RUNNING = "PlayerRunning", PLAYER_DEATH = "PlayerDeath", PLAYER_JUMP = "PlayerJump";



    void Start()
    {   
        //rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
    }

     void FixedUpdate()
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

        //to check if the player is on the ground to toggle animation
        if (IsGrounded())
        {
            if (rightPressed || leftPressed)
            {
                ChangeAnimationState(PLAYER_RUNNING);
            }
            if (isAttackPressed)
            {
                isAttackPressed = false;
                if (!attacking)
                {
                    attacking = true;
                    ChangeAnimationState(PLAYER_ATTACK);
                    attackDelay = animator.GetCurrentAnimatorStateInfo(0).length;
                    Invoke("AttackComplete", attackDelay);
                }
            }
            else if(!attacking && !rightPressed && !leftPressed)
            {
                 ChangeAnimationState(PLAYER_IDLE);
            }
        }
        else
        {
            ChangeAnimationState(PLAYER_JUMP);
        }
        
       

        //movement
        /* 
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

    //get input from UI button
    public void MoveRight()
    {
        rightPressed = true;
        leftPressed = false;
    }
    //get input from UI button
    public void MoveLeft()
    {
        leftPressed = true;
        rightPressed = false;
    }
    //get input from UI button
    public void ButtonUp()
    {
        rightPressed = false;
        leftPressed = false;
    }

    //function to trigger jump
    public void Jump()
    {
       
        if (IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpingPower);
            
        }
    }

    //checks if attack key is pressed
    public void Attack()
    {
        isAttackPressed = true;
    }
    
    //disable attack 
    void AttackComplete()
    {
        attacking = false;
    }
    
    //check if the player is on ground or not
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void ChangeAnimationState(string newState)
    {
        //This will stop the same animation from interruting itself
        if (currentState == newState)
            return;
        //play the animation
        animator.Play(newState);
    }
}
