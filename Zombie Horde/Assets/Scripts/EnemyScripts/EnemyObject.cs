﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy")]
public class EnemyObject : ScriptableObject
{
    [Header("Health/Damage")]
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown;
    [Space]
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float slowSpeed;
    [SerializeField] private Tile[] slowTiles;
    [SerializeField] private float minimumDistance;
    [SerializeField] private float maximumDistance;
    [Space]
    [Header("Visual")]
    [SerializeField] private Sprite[] zombieVariants;
    [SerializeField] private Vector3 size;

    public void SetUp(EnemyMovement enemyMovement, EnemyHealth enemyHealth, Transform target, Tilemap backgroundTilemap, GameObject enemy, EnemyAttack enemyAttack)
    {
        enemyHealth.currentHealth = health;

        enemyMovement.speed = speed;
        enemyMovement.target = target;
        enemyMovement.minimumDistance = minimumDistance;
        enemyMovement.maximumDistance = maximumDistance;
        enemyMovement.slowTiles = slowTiles;
        enemyMovement.slowSpeed = slowSpeed;
        enemyMovement.backgroundTilemap = backgroundTilemap;

        enemy.transform.localScale = size;
        enemy.GetComponentInChildren<SpriteRenderer>().sprite = zombieVariants[Random.Range(0, zombieVariants.Length)];
        enemy.name = this.name;

        enemyAttack.damage = damage;
        enemyAttack.attackCooldown = attackCooldown;
    }
}
