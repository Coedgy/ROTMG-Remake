using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    float timeStamp = 0;

    float timerLeft = 0;
    bool timerOn = false;

    Vector3 mousePosition;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        timeStamp = Time.time;
    }


    void Update()
    {
        if (Input.GetButton("Fire1") && timeStamp <= Time.time && !UIManager.MouseOverUI())
        {
            if (gameObject.GetComponent<Player>().weapon != null)
            {
                Shoot();
                timeStamp = Time.time + (60f / (gameObject.GetComponent<Player>().attackSpeed * gameObject.GetComponent<Player>().weapon.fireRate) / 100);
            }
            else
            {
                Debug.Log("No weapon equipped!");
            }
        }

        if (timerOn)
        {
            timerLeft -= 0.1f;

            if (timerLeft <= 0)
            {
                Timer();
            }
        }
    }

    void Shoot()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition) + new Vector3(0, -0.4f, 0);

        Vector3 difference = mousePosition - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        Weapon weapon = gameObject.GetComponent<Player>().weapon;

        GameObject bullet = Instantiate(weapon.bulletPrefab, (transform.position + new Vector3(0, 0.4f, 0)), Quaternion.Euler(0.0f, 0.0f, rotationZ));
        Bullet script = bullet.GetComponent<Bullet>();

        //TestWeapon attributes
        script.damage = ((float)Random.Range(weapon.minDamage,weapon.maxDamage)) * gameObject.GetComponent<Player>().damageMultiplier;
        script.speed = weapon.speed;
        script.range = weapon.range;
        script.owner = gameObject.GetComponent<Player>();

        //Animation
        anim.SetFloat("MouseDirX", (Input.mousePosition.x / Camera.main.pixelWidth) - 0.406f);
        anim.SetFloat("MouseDirY", (Input.mousePosition.y / Camera.main.pixelHeight) - 0.54f);
        anim.SetTrigger("ShootEvent");
        timerOn = true;
        timerLeft = 1f;
    }

    void Timer()
    {
        anim.ResetTrigger("ShootEvent");
        timerOn = false;
        timerLeft = 0;
    }
}
