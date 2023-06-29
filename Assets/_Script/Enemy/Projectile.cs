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
  
    void Update()
    {
        if (hit) return;
        transform.Translate(AttackDirection* speed * Time.deltaTime);

        lifetime += Time.fixedDeltaTime;
        if (lifetime > 2) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DamageArea")
        {
            hit = true;
            edgeCollider.enabled = false;
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
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

    public void OnBecameInvisible()
    {
        gameObject.SetActive(false);

    }
}
