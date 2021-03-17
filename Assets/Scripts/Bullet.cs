using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
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
            enemy.TakeDamage(Random.Range(20, 40));
        }
        Destroy(gameObject);
    }

}
