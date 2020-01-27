using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "New Enemy")]
public class EnemyObject : ScriptableObject
{
    public float health;
    public float speed;
    public float minimumDistance;
    public float maximumDistance;
    public Sprite enemySprite;

    public void SetUp(EnemyMovement enemyMovement, Transform target)
    {
        enemyMovement.speed = speed;
        enemyMovement.target = target;
        enemyMovement.minimumDistance = minimumDistance;
        enemyMovement.maximumDistance = maximumDistance;
    }
}
