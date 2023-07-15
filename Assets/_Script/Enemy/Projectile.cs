    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Vector2 AttackDirection;
    [SerializeField] private float speed;
    private bool hit;
    private float lifetime;
    private EdgeCollider2D edgeCollider;

    private void Awake()
    {
       
        edgeCollider = GetComponent<EdgeCollider2D>();
    }
    void FixedUpdate()
    {
        if (hit) return;
        if (gameObject.tag == "BossAttack"){
            speed = 2f;   
         }
        transform.Translate(AttackDirection* speed * Time.deltaTime);
        lifetime += Time.fixedDeltaTime;

        if(gameObject.tag == "BossAttack")
        {
         if (lifetime > 5f) 
            gameObject.SetActive(false);
        }
        else
        {
            if (lifetime > 1.5f) gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if the attack is collided with monster tag enemy
        if (collision.tag == "Monster" && gameObject.tag != "BossAttack")
        {
            hit = true;
            edgeCollider.enabled = false;
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }

        if (collision.tag == "Spider" && gameObject.tag != "BossAttack")
        {
            //Debug.Log("got hit");
            hit = true;
            edgeCollider.enabled = false;
            //Destroy(collision.gameObject);
            SpiderDeath.Instance.TakeDamage(100f,collision.gameObject);
            gameObject.SetActive(false);
        }

        //checks if the attack object tag is BossAttack or not
        if (collision.gameObject.TryGetComponent(out PlayerActions player) && gameObject.tag == "BossAttack")
        {
            hit = true;
            edgeCollider.enabled = false;
            player.TakeHit();
            gameObject.SetActive(false);
        }    
    }

    //function is used to set the direction of the range attack
    public void SetDirection( Vector2 AttackDirection, int angle)
    {
        this.AttackDirection = AttackDirection;
        lifetime = 0;
        gameObject.SetActive(true);
        hit = false;
        edgeCollider.enabled = true;
        transform.rotation = Quaternion.Euler(Vector3.forward*angle);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    //deactivates the gameobject when it goes out of camera view
    public void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
