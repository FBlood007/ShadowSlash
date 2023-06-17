using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHittable
{
    [SerializeField]
    private GameObject rangeAttack;
    [SerializeField]
    private Transform boss;
    private Transform target;
    [SerializeField]
    private float attackCooldown; 
    private float timeSinceAttack;
    private bool canAttack = true;
    public int maxHealth = 100;
    static int currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;        
    }
    private void Update()
    {
        Attack();
    }
    public void Attack()
    {
        if(!canAttack)
            timeSinceAttack += Time.deltaTime;

        if(timeSinceAttack >= attackCooldown)
            canAttack = true;

        if(canAttack && target != null && Mathf.Abs(target.transform.position.y - transform.position.y) <= 1)
        {
            canAttack = false;
            timeSinceAttack = 0f;
            //Note: trigger attack animation here
        }
    }
    public void Shoot()
    {
        //instantiates range attack in the game
        GameObject attack = Instantiate(rangeAttack, boss.position, Quaternion.identity);
        Vector3 direction = new Vector3(transform.localScale.x,0);

        attack.GetComponent<Projectile>().Setup(direction);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (gameObject.name == "DamageArea" && collision.tag == "Player")
         {
            PlayerActions.TakeHit();
          }

       /* if (gameObject.name == "AttackRange" && collision.tag == "Player")
        {
            if (target == null)
            {
                this.target = gameObject.transform;
            }
        }*/
    }

    public void TakeHit()
    {
        Debug.Log("GOt hit");
    }

    public static void TakeDamage(int damage, GameObject enemy)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die(enemy);
        }
    }

     public static void Die(GameObject enemy)
    {
        Destroy(enemy);
    }

}
