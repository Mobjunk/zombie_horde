using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisplay : MonoBehaviour
{
    public float health;
    public float speed;
    public float minimumDistance;
    public float maximumDistance;
    public SpriteRenderer enemySprite;
    public EnemyObject eo;


    private void Start()
    {
        health = eo.health;
        speed = eo.speed;
        minimumDistance = eo.minimumDistance;
        maximumDistance = eo.maximumDistance;
    }
}
