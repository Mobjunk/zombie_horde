using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    InputManager inputManager => InputManager.instance;
    PlayerAttack playerAttack => PlayerAttack.instance;

    float speed = 4;
    public Rigidbody2D rb;

    private Player player;
    
    private void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        player = GameManager.playerObject.GetComponent<Player>();

    }
    private void FixedUpdate()
    {
        HandleMovement();
        playerAttack.StartSwinging();
    }
    void HandleMovement()
    {
        if (player.invetoryOpened) return;
        
        rb.velocity = new Vector2(inputManager.horizontalMovementLeftStick * speed, inputManager.verticalMovementLeftStick * speed);
    }

}
