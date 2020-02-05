using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    InputManager inputManager => InputManager.instance;
    PlayerAttack playerAttack => PlayerAttack.instance;
    ResourceSystem resourceSystem => ResourceSystem.instance;
    
    /// <summary>
    /// The game object for the inventory ui
    /// </summary>
    public GameObject inventoryUI;
    /// <summary>
    /// The game object for the crafting ui
    /// </summary>
    public GameObject craftingUI;
    /// <summary>
    /// Check if the player has his inventory opened
    /// </summary>
    [HideInInspector] public bool invetoryOpened = false;
    /// <summary>
    /// Check if the player has his crafting interface opened
    /// </summary>
    [HideInInspector] public bool craftingOpened = false;
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
        OpenCrafting();

        if (AllowedToScroll())
        {
            if (!weapon.Shoot())
            {
                playerAttack.StartSwinging();
                resourceSystem.DestroyResource(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
            }
            weapon.Reload();
        }

    }

    public void Add()
    {
        inventory.Add(3);
        inventory.Add(4, 100);
    }

    void OpenInventory()
    {
        if (!Input.GetKeyDown(KeyCode.E) || craftingOpened) return;
        invetoryOpened = !invetoryOpened;
        inventoryUI.SetActive(invetoryOpened);
    }

    void OpenCrafting()
    {
        if (!Input.GetKeyDown(KeyCode.C) || invetoryOpened) return;
        craftingOpened = !craftingOpened;
        craftingUI.SetActive(craftingOpened);
    }

    public bool AllowedToScroll()
    {
        return !invetoryOpened && !craftingOpened;
    }
    
    void SwitchSlot()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && AllowedToScroll()) inventorySlot--;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && AllowedToScroll()) inventorySlot++;
        
        if (inventorySlot > 8) inventorySlot = 0;
        else if (inventorySlot < 0) inventorySlot = 8;
        
        if(inputManager.pressedOne) inventorySlot = 0;
        if(inputManager.pressedTwo) inventorySlot = 1;
        if(inputManager.pressedThree) inventorySlot = 2;
        if(inputManager.pressedFour) inventorySlot = 3;
        if(inputManager.pressedFive) inventorySlot = 4;
        if(inputManager.pressedSix) inventorySlot = 5;
        if(inputManager.pressedSeven) inventorySlot = 6;
        if(inputManager.pressedEight) inventorySlot = 7;
        if(inputManager.pressedNine) inventorySlot = 8;
    }
}
