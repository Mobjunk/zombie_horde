﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    InputManager inputManager => InputManager.instance;

    float speed = 4;
    public Rigidbody2D rb;
    
    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        HandleMovement();
     
    }
    void HandleMovement()
    { 
        rb.velocity = new Vector2(inputManager.horizontalMovement * speed, inputManager.verticalMovement * speed);
    }

}