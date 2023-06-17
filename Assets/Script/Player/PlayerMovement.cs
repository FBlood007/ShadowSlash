using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public float speed = 1f; //speed of the player
    public float jumpingPower = 400f; //jump force
    private bool rightPressed = false;
    private bool leftPressed = false;
    private bool isAttackPressed; //bool variable to check if attack key is pressed
    private bool attacking; //bool variable to check if player is attacking or not
    public static int life = 3;

    public GameObject player;
    [SerializeField] private float attackDelay; //variable to dealy the animation after attack is done
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private PlayerActions actions;

    //Animation states
    const string PLAYER_IDLE = "PlayerIdle", 
        PLAYER_ATTACK = "PlayerAttack", 
        PLAYER_RECOVERY = "PlayerRecovery",
        PLAYER_COMBAT = "PlayerCombat", 
        PLAYER_HURT = "PlayerHurt", 
        PLAYER_RUNNING = "PlayerRunning", 
        PLAYER_DEATH = "PlayerDeath", 
        PLAYER_JUMP = "PlayerJump";



    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        UIManager.Instance.AddLife(life);
        //actions = new PlayerActions(this);
    }
    void Update()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
    }

     void FixedUpdate()
    {   
        //moves player to the right when button pressed
        if (rightPressed)
        {
            
            transform.Translate(Vector2.right * speed * Time.deltaTime);
           player.transform.localScale = new Vector2(-2.035237f, 1.875094f);
        }
        //moves player to the left when button pressed
        if (leftPressed)
        {
            transform.Translate(Vector2.right * -1 * speed * Time.deltaTime);
            player.transform.localScale = new Vector2(2.035237f, 1.875094f);
        }

        //to check if the player is on the ground to toggle animation
        if (IsGrounded())
        {
            //on press of right/left button animation will change to running
            if (rightPressed || leftPressed)
            {
                AnimationHandling.ChangeAnimationState(PLAYER_RUNNING);
            }
            //checks weither attack button is pressed
            if (isAttackPressed)
            {
                isAttackPressed = false;
                //checks if player is attacking if not the attack animation will be set
                if (!attacking)
                {
                    attacking = true;
                    AnimationHandling.ChangeAnimationState(PLAYER_ATTACK);
                    float delay = AnimationHandling.animator.GetCurrentAnimatorStateInfo(0).length;
                    //calls the method after certain delay - it calls AttackComplete() after attack animation is completed
                    Invoke("AttackComplete", delay);
                }
            }
            //sets the animation to idle if player in not moving and not attacking 
            else if(!attacking && !rightPressed && !leftPressed)
            {
                AnimationHandling.ChangeAnimationState(PLAYER_IDLE);
            }
        }
        else
        {
            //if player is not 
            AnimationHandling.ChangeAnimationState(PLAYER_JUMP);
        }
        
       

        //movement for computer inputs
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

    public PlayerActions Actions
    {
        get
        {
            return actions;
        }
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

   
}
