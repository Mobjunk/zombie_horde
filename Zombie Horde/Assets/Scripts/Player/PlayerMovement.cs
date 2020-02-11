using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    [SerializeField] private Tilemap backgroundTilemap;
    [SerializeField] private Tile[] slowTiles;

    InputManager inputManager => InputManager.instance;

    [SerializeField] private float speed = 4;
    [SerializeField] private float slowSpeed = 2;
    [SerializeField] private float timer = 0;

    public GameObject waterWalkEffect;
    bool spawnParticle;

    float _horizontal;
    float _vertical;

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
        timer += Time.deltaTime;
        if(timer > 1)
        {
            spawnParticle = true;
        }
        if(timer < 1)
        {
            spawnParticle = false;
        }
        if (OpenPauseMenu.pauseMenuOpen) return;
        HandleMovement();
    }
    void HandleMovement()
    {
        float _horizontal = inputManager.horizontalMovementLeftStick;
        float _vertical = inputManager.verticalMovementLeftStick;
        Vector2 inputVector = new Vector2(_horizontal, _vertical);
        inputVector.Normalize();

        if (player.inventoryOpened || player.craftingOpened || OpenPauseMenu.pauseMenuOpen) return;

        Vector3Int gridPosition = backgroundTilemap.WorldToCell(this.transform.position);
        TileBase tile = backgroundTilemap.GetTile(gridPosition);
        if (tile != null)
        {
            foreach (var slowTile in slowTiles)
            {
                if (slowTile.name == tile.name)
                {
                    rb.velocity = inputVector * slowSpeed;

                    if (spawnParticle == true)
                    {
                        Instantiate(waterWalkEffect, this.transform.position, Quaternion.identity);
                        timer = 0;

                    }
                    return;
                }
            }
        }

        rb.velocity = inputVector*speed;
    }

}
