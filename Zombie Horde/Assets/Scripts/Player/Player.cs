using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The game object for the inentory ui
    /// </summary>
    public GameObject invetoryUI;
    /// <summary>
    /// Check if the player has his inventory opened
    /// </summary>
    [HideInInspector] public bool invetoryOpened = false;
    /// <summary>
    /// The players inventory
    /// </summary>
    public Container inventory;
    /// <summary>
    /// The slot currently selected in the hotbar
    /// </summary>
    public int inventorySlot = 0;
    /// <summary>
    /// Handles weapons
    /// </summary>
    public Weapon weapon;

    private void Start()
    {
        inventory = new Container(36);
        weapon = new Weapon(this);

        Add();
    }

    private void Update()
    {
        SwitchSlot();
        OpenInventory();
        
        weapon.Shoot();
        weapon.Reload();
    }

    public void Add()
    {
        inventory.Add(3);
        inventory.Add(4, 100);
    }

    void OpenInventory()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        invetoryOpened = !invetoryOpened;
        invetoryUI.SetActive(invetoryOpened);
    }
    
    void SwitchSlot()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) inventorySlot--;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) inventorySlot++;
        
        if (inventorySlot > 8) inventorySlot = 0;
        else if (inventorySlot < 0) inventorySlot = 8;
    }
}
