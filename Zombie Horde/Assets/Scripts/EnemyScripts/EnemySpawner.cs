using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Debug.Log(startingAmount + zombiesPerDay * days);
        //every night it will run this for loop and spawns the amount of zombies. (startingAmount + zombiesPerDay * days)
        for (int i = 0; i < startingAmount + zombiesPerDay * days; i++)
        {   
            GameObject testEnemy = Instantiate(enemy, target.position + Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(20, 0, 0), Quaternion.identity);
           
            // if less then 3 days have passed then normal zombies will spawn
            if(days < 3)
            {
                eo[0].SetUp(testEnemy.GetComponent<EnemyMovement>(), testEnemy.GetComponent<EnemyAttack>(), target);
            }
            // if more than 3 days have passed than better zombies will spawn
            if(days >= 3){
                eo[1].SetUp(testEnemy.GetComponent<EnemyMovement>(), testEnemy.GetComponent<EnemyAttack>(), target);
            }
        }
    }
}
