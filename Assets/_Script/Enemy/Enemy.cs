using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    [SerializeField] private ParticleSystem deathParticles;
    //[SerializeField] private GameObject rangeAttack;//Attack range of the enemy

    [SerializeField] private GameObject AttakProjectilePrefab;
    [SerializeField]List<GameObject> EnemyAttackList = new List<GameObject>();

    [SerializeField]
    private Transform boss;
    private Transform target;
    [SerializeField]
    private float attackCooldown;//cooldown for attacks
    //private float timeSinceAttack;
    private bool canAttack = true;
    public int maxHealth = 100;
    static int currentHealth;
   
    public AudioClip clip;
    
    private void Start()
    {
        currentHealth = maxHealth;
        
    }
    private void Update()
    {
        //Attack();
    }

    //Boss enemy attack function
    public void Attack()
    {
        //AnimationHandling.Instance.ChangeAnimationState("TreeMonsterAttack");

       /* if(!canAttack)
            timeSinceAttack += Time.deltaTime;

        if(timeSinceAttack >= attackCooldown)
            canAttack = true;

        if(canAttack && target != null && Mathf.Abs(target.transform.position.y - transform.position.y) <= 1)
        {
            canAttack = false;
            timeSinceAttack = 0f;
            //Note : trigger attack animation here
        }*/
    }

 
    //function of enemy range attack 
    public void Shoot()
    {
       
        //OBJECT POOLING
        if(canAttack) { 
            if (EnemyAttackList.Count < 6 )
            {
                //instantiates range attack in the game
                GameObject attack = Instantiate(AttakProjectilePrefab, boss.position, Quaternion.identity);
                Vector3 direction = new Vector3(-boss.localScale.x, 0);
                attack.GetComponent<Projectile>().SetDirection(direction, 0);
                EnemyAttackList.Add(attack);
              
            }
            else
            {
                EnemyAttackList[ReturnSlashFromPool()].transform.position = boss.position;
                Vector3 Slashdirection = new Vector3(-boss.localScale.x, 0);
                EnemyAttackList[ReturnSlashFromPool()].GetComponent<Projectile>().SetDirection(Slashdirection, 0);
            }
          }
        StartCoroutine(AttackDelay());
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //updated statement to detect the collision and give damage to player
         if(collision.gameObject.TryGetComponent(out PlayerActions player))
        {
           player.TakeHit();
        }

        if (gameObject.tag == "Monster" && collision.gameObject.tag == "RangeAttack")
        {
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                Vector3 pos = collision.transform.position;
                deathParticles.transform.position = new Vector3(pos.x + 2.905f,pos.y,pos.z);
            }
            else
            {
            deathParticles.transform.position = boss.transform.position;

            }
        
            deathParticles.Play();
            if(SceneManager.GetActiveScene().name == "Level_2")
            {
                UIManager.Instance.AddObjectiveCount();
            }
        }

      /*  if (gameObject.name == "AttackRange" && collision.tag == "Player")
        {
            if (target == null)
            {
                this.target = gameObject.transform;
            }
        }*/
    }

    //function in which damage taken by player is calculated
    public static void TakeDamage(int damage, GameObject enemy)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die(enemy);
        }
    }

    //function to destory enemy object
     public static void Die(GameObject enemy)
    {
        Destroy(enemy);
    }

    //function to get the index of the inactive Slash object from hierarchy
    private int ReturnSlashFromPool()
    {
        for (int i = 0; i < EnemyAttackList.Count; i++)
        {
            if (!EnemyAttackList[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    //function to delay the enemy attacks
    private IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(2);
        canAttack = true;
    }
}
