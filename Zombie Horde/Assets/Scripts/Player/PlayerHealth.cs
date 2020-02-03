using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public float startingHealth = 100f;
    public float currentHealth;



    public Image healthBar;
    public Text healthText;

    public bool playerVuln;
    public bool playerAlive;

    void Awake()
    {
        instance = this;
        currentHealth = startingHealth;
        playerVuln = true;
        //Find the HP bar object and retrieve the image component
    }

    public void TakeDamage(float amount)
    {
        if (playerVuln)
        {
            currentHealth -= amount;
            //Checks if health drops below a threshold and switches to game over scene
            if (currentHealth <= 0)
            {
                playerAlive = false;
                Destroy(this.gameObject, 0.2f);
            }
            else
            {
                playerAlive = true;
                PlayerInvuln();
            }
        }
    }
    void PlayerInvuln()
    {
        playerVuln = false;
        //Sets the material of the player to white so indicate invulnerability
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        //Wait for 2 seconds before performing the following action
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        playerVuln = true;
    }
    private void Update()
    {
        healthBar.fillAmount = currentHealth / startingHealth;
        healthText.text = $"{currentHealth}/{startingHealth}";
    }
}
