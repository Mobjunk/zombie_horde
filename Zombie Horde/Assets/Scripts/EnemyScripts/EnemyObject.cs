using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy")]
public class EnemyObject : ScriptableObject
{
    public float health;
    public float damage;
    public float attackSpeed;
    public float attackCooldown;
    public float speed;
    public float slowSpeed;
    public Tile[] slowTiles;
    public float minimumDistance;
    public float maximumDistance;

    public void SetUp(EnemyMovement enemyMovement, EnemyHealth enemyHealth, Transform target, Tilemap backgroundTilemap)
    {
        enemyHealth.currentHealth = health;
        enemyMovement.speed = speed;
        enemyMovement.target = target;
        enemyMovement.minimumDistance = minimumDistance;
        enemyMovement.maximumDistance = maximumDistance;
        enemyMovement.slowTiles = slowTiles;
        enemyMovement.slowSpeed = slowSpeed;
        enemyMovement.backgroundTilemap = backgroundTilemap;
    }
}
