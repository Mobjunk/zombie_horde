using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public EnemyObject enemyObject;

    private void TakePlayerDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        } 
    }
}
