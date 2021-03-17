using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public GameObject testBullet;

    Vector3 mousePosition;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition) + new Vector3(0, 0.3f, 0);

        Vector3 difference = mousePosition - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate(testBullet, (transform.position + new Vector3(0, -0.3f, 0)), Quaternion.Euler(0.0f, 0.0f, rotationZ));
        Bullet script = bullet.GetComponent<Bullet>();

        //TestWeapon attributes
        script.damage = Random.Range(20,30);
        script.speed = 10f;
        script.range = 3.0f;
    }
}
