using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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

    /* public void CollisionEnter(string colliderName, GameObject other)
     {
         // if (colliderName == "DamageArea" && other.tag == "Player")
         // {
         //other.GetComponent<PlayerMovement>().Actions.TakeHit();
         //}

         if (colliderName == "AttackRange" && other.tag == "Player")
         {
             if (target == null)
             {
                 this.target = other.transform;
             }
        }
     } */
}
