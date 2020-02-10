using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{
    public static bool pauseMenuOpen = false;
    [SerializeField] private GameObject pauseMenu;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.playerObject.GetComponent<Player>();
        pauseMenuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PlayerHealth.playerAlive)
        {
            if (player.invetoryOpened) player.HandleInventory(false);
            else if (player.craftingOpened) player.HandleCrafting(false);
            else togglePauseMenu();
        }
    }

    public void togglePauseMenu()
    {
        if (pauseMenuOpen)
        {
            pauseMenu.SetActive(false);
            pauseMenuOpen = false;
        }
        else
        {
            pauseMenu.SetActive(true);
            pauseMenuOpen = true;
        }
    }
}
