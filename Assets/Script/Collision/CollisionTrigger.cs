using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
   private ICollisionHandler collisionHandle;

    private void Start()
    {
        collisionHandle = GetComponentInParent<ICollisionHandler>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionHandle.CollisionEnter(gameObject.name, collision.gameObject);
    }
}
