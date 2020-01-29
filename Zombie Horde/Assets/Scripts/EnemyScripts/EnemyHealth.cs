using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;

    private void TakePlayerDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Debug.Log("erywcgqyehj");
        }
    }
}
