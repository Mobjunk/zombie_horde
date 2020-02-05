using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform target;
    [SerializeField] private Tilemap backgroundTilemap;

    public void EnemySpawning(EnemyObject enemyObject)
    {
        GameObject spawnedEnemy = Instantiate(enemy, target.position + Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(20, 0, 0), Quaternion.identity);
        enemyObject.SetUp(spawnedEnemy.GetComponent<EnemyMovement>(), spawnedEnemy.GetComponent<EnemyHealth>(), target, backgroundTilemap, spawnedEnemy, spawnedEnemy.GetComponentInChildren<EnemyAttack>());
    }
}
