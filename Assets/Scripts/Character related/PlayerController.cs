﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Vector2 velocity;
    private Rigidbody2D rb;

    public GameObject canvas;
    public GameObject pauseMenu;

    public bool movementLocked;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Settings.SM.pauseKey) && movementLocked == false)
        {
            Instantiate(pauseMenu, canvas.transform);
            movementLocked = true;
        }

        if (movementLocked)
        {
            return;
        }
        
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");
        velocity.x = moveInputX;
        velocity.y = moveInputY;

        if (moveInputX == 0 && moveInputY == 0)
        {
            anim.SetBool("isRunning", false);
        }

        if (moveInputX != 0)
        {
            anim.SetFloat("Vertical", velocity.x);
            anim.SetFloat("Vertical Last", velocity.x);
            anim.SetFloat("Horizontal Last", 0.0f);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetFloat("Vertical", velocity.x);
        }
        if (moveInputY != 0)
        {
            anim.SetFloat("Horizontal", velocity.y);
            anim.SetFloat("Horizontal Last", velocity.y);
            anim.SetFloat("Vertical Last", 0.0f);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetFloat("Horizontal", velocity.y);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * gameObject.GetComponent<Player>().movementSpeed * Time.fixedDeltaTime);
    }
}
