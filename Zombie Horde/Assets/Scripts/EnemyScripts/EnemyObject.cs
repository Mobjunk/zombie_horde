using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy")]
public class EnemyObject : ScriptableObject
{
    public int health;
    public float damage;
    public float attackSpeed;
    public float attackCooldown;
    public float speed;
    public float minimumDistance;
    public float maximumDistance;

    public void SetUp(EnemyMovement enemyMovement, EnemyAttack enemyAttack, Transform target)
    {
        enemyAttack.enemyAttackCooldown = attackCooldown;
        enemyAttack.enemyHealth = health;
        enemyMovement.speed = speed;
        enemyMovement.target = target;
        enemyMovement.minimumDistance = minimumDistance;
        enemyMovement.maximumDistance = maximumDistance;

    }
}
