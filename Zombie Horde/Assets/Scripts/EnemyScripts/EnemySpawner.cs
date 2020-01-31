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

    int random;

    public int startingAmount = 2;
    public int zombiesPerDay = 2;

    public void EnemySpawning()
    {
        random = Random.Range(0, 10);
        Debug.Log(startingAmount + zombiesPerDay * days);
        //every night it will run this for loop and spawns the amount of zombies. (startingAmount + zombiesPerDay * days)
        for (int i = 0; i < startingAmount + zombiesPerDay * days; i++)
        {   
            GameObject testEnemy = Instantiate(enemy, target.position + Quaternion.Euler(0, 0, Random.Range(0, 360)) * new Vector3(20, 0, 0), Quaternion.identity);
           
            // if less then 3 days have passed then normal zombies will spawn
            if(days < 3)
            {
                eo[0].SetUp(testEnemy.GetComponent<EnemyMovement>(), testEnemy.GetComponent<EnemyAttack>(), testEnemy.GetComponent<EnemyHealth>(), target);
            }
            // if more than 4 days have passed than better zombies will spawn
            if(days >= 4){
                eo[0].SetUp(testEnemy.GetComponent<EnemyMovement>(), testEnemy.GetComponent<EnemyAttack>(), testEnemy.GetComponent<EnemyHealth>(), target);
                if(random >= 5)
                {
                    eo[1].SetUp(testEnemy.GetComponent<EnemyMovement>(), testEnemy.GetComponent<EnemyAttack>(), testEnemy.GetComponent<EnemyHealth>(), target);
                }
            }
        }
    }
}
