using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] ParticleSystem slash = null;
    public static PlayerMovement Instance;
    void Awake() => Instance = this;

    public GameObject gameOverPopUp;
    [SerializeField]
    private SpriteRenderer[] spriteRenderers;
    [SerializeField] private float speed = 1f; //speed of the player
    public float jumpingPower = 400f; //jump force
    private bool rightPressed = false;
    private bool leftPressed = false;
    private bool isAttackPressed; //bool variable to check if attack key is pressed
    private bool attacking; //bool variable to check if player is attacking or not
    public int life;
    public bool isImmortal;
    [SerializeField]
    private float immortalityTime;
    public int level = 1;
    public int noOfLife = 3;
    Animator animator;

    private float horizontal = 0f;

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

    //Player Combat
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 100;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        life = 3;
        //rb = GetComponent<Rigidbody2D>();
        UIManager.Instance.AddLife(life);
        isImmortal = false;
        if (SceneManager.GetActiveScene().name == "Level_1")
        {
            
            AudioManager.Instance.PauseSound("MainMenu");
            AudioManager.Instance.PlaySound("Level1");
        }
        slash.Stop();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

     void FixedUpdate()
    {
        //moves player to the right when button pressed
        if (rightPressed)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(-2.035237f, 1.875094f);
        }
        //moves player to the left when button pressed
        if (leftPressed)
        {
            transform.Translate(Vector2.right * -1 * speed * Time.deltaTime);
            transform.localScale = new Vector2(2.035237f, 1.875094f);
        }

        //to check if the player is on the ground to toggle animation
        if (IsGrounded())
        {
            //on press of right/left button animation will change to running
            if (rightPressed || leftPressed)
            {
                //Before
                // FindObjectOfType<AnimationHandling>().ChangeAnimationState(PLAYER_RUNNING);

                //After
                AnimationHandling.Instance.ChangeAnimationState(PLAYER_RUNNING);
            }
            //checks weither attack button is pressed
            if (isAttackPressed)
            {
                isAttackPressed = false;
                //checks if player is attacking if not the attack animation will be set
                if (!attacking)
                {
                    attacking = true;

                    AnimationHandling.Instance.ChangeAnimationState(PLAYER_ATTACK);
                    //FindObjectOfType<AnimationHandling>().ChangeAnimationState(PLAYER_ATTACK);

                    slash.Play();
                 

                    AudioManager.Instance.PlaySound("Attack");
                    //FindObjectOfType<AudioManager>().PlaySound("Attack");
                    float delay = animator.GetCurrentAnimatorStateInfo(0).length;

                    //calls the method after certain delay - it calls AttackComplete() after attack animation is completed
                    Invoke("AttackComplete", delay);
                }
            }
            if (life < 0)
            {

                AnimationHandling.Instance.ChangeAnimationState(PLAYER_DEATH);
                //FindObjectOfType<AnimationHandling>().ChangeAnimationState(PLAYER_DEATH);

                gameOverPopUp.SetActive(true);
                Time.timeScale = 0f;
            }
            //sets the animation to idle if player in not moving and not attacking 
            else if (!attacking && !rightPressed && !leftPressed)
            {
                AnimationHandling.Instance.ChangeAnimationState(PLAYER_IDLE);
                //FindObjectOfType<AnimationHandling>().ChangeAnimationState(PLAYER_IDLE);
            }
        }
        else
        {
            AnimationHandling.Instance.ChangeAnimationState(PLAYER_JUMP);
            //FindObjectOfType<AnimationHandling>().ChangeAnimationState(PLAYER_JUMP);
        }



        //movement for computer inputs
        /* transform.Translate(Vector2.right * horizontal * speed * Time.deltaTime);

         if (IsGrounded())
         {
             if(horizontal != 0)
             {
                 if (horizontal < 0)
                 {
                     transform.localScale = new Vector2(2.035237f, 1.875094f);
                 }
                 if (horizontal > 0)
                 {

                     transform.localScale = new Vector2(-2.035237f, 1.875094f);
                 }
                 AnimationHandling.Instance.ChangeAnimationState(PLAYER_RUNNING);
             }
             if (isAttackPressed)
             {
                 isAttackPressed = false;
                 //checks if player is attacking if not the attack animation will be set
                 if (!attacking)
                 {
                     attacking = true;

                     AnimationHandling.Instance.ChangeAnimationState(PLAYER_ATTACK);

                     AudioManager.Instance.PlaySound("Attack");
                     //FindObjectOfType<AudioManager>().PlaySound("Attack");

                     float delay = animator.GetCurrentAnimatorStateInfo(0).length;

                     //calls the method after certain delay - it calls AttackComplete() after attack animation is completed
                     Invoke("AttackComplete", delay);
                 }
             }
             else if(horizontal == 0 && !attacking)
             {
                 AnimationHandling.Instance.ChangeAnimationState(PLAYER_IDLE);
             }
         }
         else
         {
             if (horizontal < 0)
                 transform.localScale = new Vector2(2.035237f, 1.875094f);

             if (horizontal > 0)
                 transform.localScale = new Vector2(-2.035237f, 1.875094f);
             AnimationHandling.Instance.ChangeAnimationState(PLAYER_JUMP);
         }

         if (Input.GetButton("Jump"))
         {
             if (IsGrounded())
             {
                 rb.AddForce(Vector2.up * 100f);
             }
         }
         if (Input.GetButton("Fire1"))
         {
             Attack();

         }*/


    }

    public PlayerActions Actions
    {

        get
        {
            return actions;
        }
    }


    public float ImmortalityTime { get => immortalityTime; set => immortalityTime = value; }
    public SpriteRenderer[] SpriteRenderers { get => spriteRenderers; set => spriteRenderers = value; }

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
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Enemy.TakeDamage(attackDamage,enemy.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
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
