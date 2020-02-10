using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public float startingHealth = 100f;
    public float currentHealth;



    public Image healthBar;
    public Text healthText;

    public bool playerVuln;
    public static bool playerAlive;

    [SerializeField] private UnityEvent OnPlayerDie = new UnityEvent();

    void Awake()
    {
        instance = this;
        currentHealth = startingHealth;
        playerVuln = true;
        playerAlive = true;
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
                OnPlayerDie.Invoke();
                Destroy(this.gameObject, 0.2f);
            }
            else
            {
                playerAlive = true;
                //PlayerInvuln();
            }
        }
    }
    void PlayerInvuln()
    {
        playerVuln = false;
        //Sets the material of the player to white so indicate invulnerability
        //gameObject.GetComponent<Renderer>().material.color = Color.red;
        //StartCoroutine(waiter());
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
