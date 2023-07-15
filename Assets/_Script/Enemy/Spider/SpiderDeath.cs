using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderDeath : MonoBehaviour
{
    public static SpiderDeath Instance;
    [SerializeField] private Slider slider;
    
    public float health, maxHealth = 1000f;
    public GameObject deathEffect;

    void Awake() => Instance = this;
    //public bool isInvulnerable = false;
    public void Start()
    {
        UpdateHealthBar();
        Debug.Log("Spider health " + health);
    }

    public void UpdateHealthBar()
    {
        slider.value = health / maxHealth;
        
    }

    public void TakeDamage(float damage, GameObject spider)
    {
        /*if (isInvulnerable)
            return;*/        
        health -= damage;
        Debug.Log("spider Damage "+ health);
        UpdateHealthBar();
        if (health <= 0)
        {
            Die(spider);
        }
    }

    void Die(GameObject spider)
    {
        Debug.Log("Die function");
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        UIManager.Instance.AddObjectiveCount();
        Destroy(spider);
    }
}
