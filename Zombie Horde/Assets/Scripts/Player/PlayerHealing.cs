using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealing : MonoBehaviour
{
    GameManager gameManager => GameManager.instance;
    PlayerHealth playerHealth => PlayerHealth.instance;
    
    private Player player;
    private float lastEat = 0f;
    
    void Start()
    {
        player = GameManager.playerObject.GetComponent<Player>();
    }

    void Update()
    {
        if (player.inputManager.placeStructure && lastEat <= 0)
        {
            var item = player.inventory.Get(player.inventorySlot).item;
            var food = item.food;
            if (food == null) return;

            gameManager.soundPlayer.PlaySound(Sounds.PLAYER_EATING);
            
            player.inventory.Remove(item.itemId, 1);
            
            playerHealth.currentHealth += food.healthIncrease;
            
            if (playerHealth.currentHealth > playerHealth.startingHealth)
                playerHealth.currentHealth = playerHealth.startingHealth;
        }
    }
}
