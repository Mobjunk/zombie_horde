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
    public LayerMask structure;
    public float attackCooldown;
    public float damage;
    [SerializeField] private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        buildingSystem = FindObjectOfType<BuildingSystem>();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Time.time > timer)
        {
            RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, Vector2FromAngle(enemy.transform.eulerAngles.z), 1f,layerMask);
            RaycastHit2D hit1 = Physics2D.Raycast(enemy.transform.position, Vector2FromAngle(enemy.transform.eulerAngles.z + 30), 1f, layerMask);
            RaycastHit2D hit2 = Physics2D.Raycast(enemy.transform.position, Vector2FromAngle(enemy.transform.eulerAngles.z - 30), 1f, layerMask);
            if (hit.collider != null)
            {
                HitObject(hit, Vector2FromAngle(enemy.transform.eulerAngles.z) * new Vector2(0.1f, 0.1f));
            }

            else if (hit1.collider != null)
            {
                HitObject(hit1, Vector2FromAngle(enemy.transform.eulerAngles.z + 30) * new Vector2(0.1f, 0.1f));
            }

            else if (hit2.collider != null)
            {
                HitObject(hit2, Vector2FromAngle(enemy.transform.eulerAngles.z - 30) * new Vector2(0.1f, 0.1f));
            }
        }

    }

    public void Attack()
    {
        playerHealth.TakeDamage(damage);
        timer = Time.time + attackCooldown;
    }

    public void HitObject(RaycastHit2D hit, Vector2 addedVector)
    {
        Debug.LogError(hit.collider.gameObject);
        if (hit.collider.gameObject.layer == 9)
        {
            buildingSystem.DestroyStructure(hit.point + addedVector, damage);
            timer = Time.time + attackCooldown;

        }
        else if (hit.collider.gameObject.layer == 10)
        {
            Attack();
        }
    }

    private Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }
}
