using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //public static EnemyHealth instance;

    public float currentHealth;
    public EnemyObject enemyObject;
    public GameObject enemy;
    public GameObject bloodParticle;
    PlayerAttack playerAttack => PlayerAttack.instance;
    public void TakePlayerDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            var startRot = Quaternion.LookRotation(enemy.transform.forward - enemy.transform.forward * 2);
            Instantiate(bloodParticle, enemy.transform.position, startRot);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="PlayerFist"&&playerAttack.playerAnimator.GetBool("isPunching")==true)
        {
            Debug.Log("hit by fists");
            TakePlayerDamage(5);
        }

    }
}
