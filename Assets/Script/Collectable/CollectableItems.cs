using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectableItems : MonoBehaviour
{

    /* public void Collect()
     {

         UIManager.Instance.AddGem();
         Destroy(gameObject);

     }*/

    private Transform collectTransform;
    private bool collected = false;
    private float speed = 5f;


    private void Start()
    {
        collectTransform = GameObject.Find("CollectTransform").transform;
    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        if (collected)
        {
            transform.position = Vector3.MoveTowards(transform.position,collectTransform.position,Time.fixedDeltaTime * speed);
        }
        if(transform.position == collectTransform.position) {
            UIManager.AddGem();
            Destroy(gameObject);
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collected = true;
            //FindObjectOfType<AudioManager>().PlaySound("CoinPickUp");
        }
    }

}
