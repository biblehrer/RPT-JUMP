using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && gameObject.tag == "Enemy")
        {
            Die();
        }
        else if (health <= 0 && gameObject.tag == "Player")
        {
            // Player Death
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}