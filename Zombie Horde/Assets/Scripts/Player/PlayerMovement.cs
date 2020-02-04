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
    PlayerAttack playerAttack => PlayerAttack.instance;

    [SerializeField] private float speed = 4;
    [SerializeField] private float slowSpeed = 2;

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
        if (player.invetoryOpened || OpenPauseMenu.pauseMenuOpen) return;

        Vector3Int gridPosition = backgroundTilemap.WorldToCell(this.transform.position);
        TileBase tile = backgroundTilemap.GetTile(gridPosition);
        foreach (var slowTile in slowTiles)
        {
            if (slowTile.name == tile.name)
            {
                rb.velocity = new Vector2(inputManager.horizontalMovementLeftStick * slowSpeed, inputManager.verticalMovementLeftStick * slowSpeed);
                return;
            }
        }
        rb.velocity = new Vector2(inputManager.horizontalMovementLeftStick * speed, inputManager.verticalMovementLeftStick * speed);
    }

}
