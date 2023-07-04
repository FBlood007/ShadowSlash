using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItems : MonoBehaviour
{

    
    public GameObject collectPosition;//gameobject with position where the collectable will travel
    private Transform collectTransform;
    private bool collected = false;
    private float speed = 20f;//speed of the collectable when it travles to the U


    private void Update()
    {
        collectTransform = collectPosition.transform;
        Move();
    }

    //this function moves the collectable and then destroys it
    public void Move()
    {
        if (collected)
        {
            transform.position = Vector3.MoveTowards(transform.position, collectTransform.position, Time.deltaTime * speed);
        }
        if(transform.position == collectTransform.position) {

            UIManager.Instance.AddObjectiveCount();
            
            Destroy(gameObject);
        }
    }

   //function is for trigger enter of the collectable
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collected = true;
            //FindObjectOfType<AudioManager>().PlaySound("GemPick");
        }
    }

}
