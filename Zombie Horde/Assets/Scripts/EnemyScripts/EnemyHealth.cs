using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth;
    public EnemyObject enemyObject;

    public GameObject bloodParticle;
    PlayerAttack playerAttack => PlayerAttack.instance;
    private void TakePlayerDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {

            Destroy(this.gameObject);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("HELP");
        if(collision.gameObject.tag=="PlayerFist"&&playerAttack.playerAnimator.GetBool("isPunching")==true)
        {
            Debug.Log("enemyhealth");
            TakePlayerDamage(10);
        }
    }
}
