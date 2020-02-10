using System;
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
    public SpriteRenderer shadow;
    public DayNightCycle dayNightCycle;
    private Player player;

    PlayerAttack playerAttack => PlayerAttack.instance;

    private void Start()
    {
        player = GameManager.playerObject.GetComponent<Player>();
    }


    public void TakePlayerDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            dayNightCycle.movingShadows.Remove(shadow);
            Destroy(gameObject);
            var startRot = Quaternion.LookRotation(enemy.transform.forward - enemy.transform.forward * 2);
            Instantiate(bloodParticle, enemy.transform.position, startRot);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerFist") && playerAttack.playerAnimator.GetBool("isPunching"))
        {
            var damage = 2;
            var weapon = player.tool.Get(player.tool.GetWeapon(player.inventorySlot), player.inventorySlot);
            if (weapon != null)
            {
                damage = (int) weapon.tool.weaponDamage;
                player.tool.LoseDurability(weapon, 8);
            }
            Debug.Log($"damage: {damage}");
            TakePlayerDamage(damage);
        }

    }
}
