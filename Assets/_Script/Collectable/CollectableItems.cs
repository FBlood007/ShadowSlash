using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItems : MonoBehaviour
{

    
    public GameObject collectPosition;//gameobject with position where the collectable will travel
    private Transform collectTransform;
    private bool collected = false;
    private float speed = 20f;//speed of the collectable when it travles to the U

    private void Awake()
    {
        if (PlayerPrefs.GetString(gameObject.name) == "true")
        {
            gameObject.SetActive(false);
        }
    }

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
            //Moves the collectable to specific position
            transform.position = Vector3.MoveTowards(transform.position, collectTransform.position, Time.deltaTime * speed);
        }
        if(transform.position == collectTransform.position) {
            PlayerManager.numberOfOrbs++;
            PlayerPrefs.SetInt("NumberOfOrbs",PlayerManager.numberOfOrbs);
            PlayerPrefs.SetString(gameObject.name,"true");
            UIManager.Instance.NoOfOrbCollectedPerLevel();
          
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
