using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public EnemyObject eo;
    public Transform target;


    public void EnemySpawning()
    {
        InvokeRepeating("EnemySpawning", 1, 1);
        GameObject testEnemy = Instantiate(enemy, new Vector3(Random.Range(-10.45f, 10.45f), Random.Range(4.51f, -4.51f), 0), Quaternion.identity);
        eo.SetUp(testEnemy.GetComponent<EnemyMovement>(), target);
    }
}
