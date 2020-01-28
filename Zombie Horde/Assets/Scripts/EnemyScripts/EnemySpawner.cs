using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public EnemyObject eo;
    public Transform target;

    public int howManyEnemies = 2;

    public void EnemySpawning()
    {
        for (int i = 0; i < howManyEnemies; i++)
        {
            GameObject testEnemy = Instantiate(enemy, target.position + Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(30, 0, 0), Quaternion.identity);
            eo.SetUp(testEnemy.GetComponent<EnemyMovement>(), target);
        }
    }
}
