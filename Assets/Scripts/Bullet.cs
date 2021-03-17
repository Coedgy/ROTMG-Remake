﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //CHANGE TO PUBLIC
    float speed = 10f;
    float range = 3f;
    public int damage = 20;
    public Rigidbody2D rb;

    Vector3 startPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = transform.position + (transform.right / 5);
        startPoint = gameObject.transform.position;
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        if (Vector3.Distance(startPoint, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.GetComponent<Player>())
        {
            return;
        }

        Debug.Log(hitInfo.gameObject);
        TestEnemy enemy = hitInfo.GetComponent<TestEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
