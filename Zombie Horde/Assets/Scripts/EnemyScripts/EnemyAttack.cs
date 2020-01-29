using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyAttack : MonoBehaviour
{
    BuildingSystem buildingSystem;
    public EnemyObject enemyObject;
    public float timer;
    public bool canAttack;
    public LayerMask structure;
    public int enemyHealth;
    public float enemyAttackSpeed;
    public float enemyAttackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        buildingSystem = FindObjectOfType<BuildingSystem>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= enemyObject.attackCooldown)
        {
            canAttack = true;
        }
        if(timer < enemyObject.attackCooldown)
        {
            canAttack = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == structure)
        {
            buildingSystem.DestroyStructure(collision.GetContact(0).point, 1);
        }

        if(collision.gameObject.layer == 10)
        {
            if (canAttack == true)
            {
                Attack();
            }

                    
        }
    }

    public void Attack()
    {
        Debug.Log("attacked");
        timer = 0;
    }
}
