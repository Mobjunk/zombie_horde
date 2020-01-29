using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public EnemyObject[] eo;
    public Transform target;
    public int days;

    public int startingAmount = 2;
    public int zombiesPerDay = 2;

    public void EnemySpawning()
    {
        for (int i = 0; i < startingAmount + zombiesPerDay * days; i++)
        {   
            GameObject testEnemy = Instantiate(enemy, target.position + Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(20, 0, 0), Quaternion.identity);
            if(days < 3){
                eo[0].SetUp(testEnemy.GetComponent<EnemyMovement>(), target);
            }
            if(days > 3){
                eo[1].SetUp(testEnemy.GetComponent<EnemyMovement>(), target);
            }
        }
    }
}
