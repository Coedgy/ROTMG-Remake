using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;

    public void TakeDamage(float damage)
    {
        health -= Mathf.CeilToInt(damage);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject + " was killed");
        Destroy(gameObject);
    }
}
