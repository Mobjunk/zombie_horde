using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth playerHealth => PlayerHealth.instance;
    BuildingSystem buildingSystem;
    
    public EnemyObject enemyObject;
    public GameObject enemy;
    public float timer;
    public bool canAttack;
    public LayerMask structure;
    public float enemyAttackSpeed;

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Debug.Log("refa");
            if(canAttack == true)
            {
                buildingSystem.DestroyStructure(this.GetComponent<CircleCollider2D>().gameObject.transform.position, 1);
                
            }
        }

        if (collision.gameObject.layer == 10)
        {
            if (canAttack == true)
            {
                Attack();
            }


        }
    }

    public void Attack()
    {
        playerHealth.TakeDamage(enemyObject.damage);
        timer = 0;
    }
}
