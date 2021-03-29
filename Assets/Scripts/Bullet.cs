using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float range = 3f;
    public float damage = 20;
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
        if (hitInfo.gameObject.GetComponent<Player>() || hitInfo.gameObject.GetComponent<Bullet>() || hitInfo.gameObject.GetComponent<ContainerScan>())
        {
            return;
        }

        Debug.Log(hitInfo.gameObject);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
