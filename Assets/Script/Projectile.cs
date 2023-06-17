using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed;

    private Vector2 direction;

    [SerializeField] private string targetTag;
 

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction *  speed * Time.deltaTime);
    }

    public void Setup(Vector2 direction)
    {
        this.direction = direction; 
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       /* if(collision.tag == targetTag)
        {

        }*/


       /* if (collision.gameObject.tag == "Player")
        {
            UIManager.Instance.RemoveLife();
            //FindObjectOfType<AudioManager>().PlaySound("CoinPickUp");
        }*/
    }
}
