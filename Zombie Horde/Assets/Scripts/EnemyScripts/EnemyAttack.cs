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
    public float attackCooldown;
    public float damage;
    [SerializeField] private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        buildingSystem = FindObjectOfType<BuildingSystem>();
        
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= attackCooldown)
        {
            canAttack = true;
        }
        if(timer < attackCooldown)
        {
            canAttack = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.LogError("overlap");
        if (canAttack == true)
        {
            
            RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, enemy.transform.rotation * Vector2.up, 10f,layerMask);
            //RaycastHit2D hit1 = Physics2D.Raycast(this.transform.parent.transform.position, Vector2.down + new Vector2(0, -0.5f), layerMask);
            //RaycastHit2D hit2 = Physics2D.Raycast(this.transform.parent.transform.position, Vector2.down + new Vector2(0,0.5f), 10f, layerMask);
            if (hit.collider != null)
            {
                HitObject(hit);
            }
            
            //else if(hit1.collider != null)
            //{
            //    HitObject(hit1);
            //}
            
            //else if(hit2.collider != null)
            //{
            //    HitObject(hit2);
            //}
        }

    }

    public void Attack()
    {
        playerHealth.TakeDamage(damage);
        timer = 0;
    }

    public void HitObject(RaycastHit2D hit)
    {
        Debug.LogError(hit.collider.gameObject);
        if (hit.collider.gameObject.layer == 9)
        {
            Debug.Log("fergsesrbgersdgdfg3erdhfweysgvauwehgfiuwegfukwsresdgfwe");
            buildingSystem.DestroyStructure(hit.point, 1);
            timer = 0;

        }

        if (hit.collider.gameObject.layer == 10)
        {
            Attack();
        }
    }
}
