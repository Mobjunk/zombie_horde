using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public GameObject scoreCanvas;

    public float startingHealth = 100f;
    public float currentHealth;



    public Image healthBar;

    bool playerVuln;

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
                
                //SceneManager.LoadScene("GameOver");
            }
            else
            {
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
    }
}
