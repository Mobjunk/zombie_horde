using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public InputManager inputManager => InputManager.instance;
    public PlayerAttack playerAttack => PlayerAttack.instance;
    ResourceSystem resourceSystem => ResourceSystem.instance;

    private GameObject leftHand, rightHand;
    private SpriteRenderer weaponRender;
    
    /// <summary>
    /// The game object for the inventory ui
    /// </summary>
    public GameObject inventoryUI;
    /// <summary>
    /// The game object for the crafting ui
    /// </summary>
    public GameObject craftingUI;

    public Text itemName;
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
    /// Handles the gun
    /// </summary>
    public Gun gun;

    public Tool tool;
    
    /// <summary>
    /// A list of all the weapons the player has
    /// </summary>
    [HideInInspector] public List<Guns> guns = new List<Guns>();

    /// <summary>
    /// A listt of all the tools the player has
    /// </summary>
    [HideInInspector]public List<Tools> tools = new List<Tools>();

    private void Start()
    {
        leftHand = GameManager.playerObject.transform.GetChild(0).gameObject;
        rightHand = GameManager.playerObject.transform.GetChild(1).gameObject;
        weaponRender = rightHand.transform.GetChild(0).GetComponent<SpriteRenderer>();
        
        inventory = new Container(36);
        gun = new Gun(this);
        tool = new Tool(this);

        inventory.Add(10, 100);
    }

    private void Update()
    {
        SwitchSlot();
        OpenInventory();
        OpenCrafting();

        if (AllowedToScroll())
        {
            int damage = 1;

            if (gun.CanUse() || tool.CanUse())
            {
                leftHand.SetActive(false);
                Sprite sprite = null;
                if (gun.CanUse())
                {
                    var weapon = gun.Get(gun.GetWeapon(inventorySlot), inventorySlot);
                    if (weapon == null) return;
                    sprite = weapon.gun.weaponSpriteHand;
                    
                } else if (tool.CanUse())
                {
                    var weapon = tool.Get(tool.GetWeapon(inventorySlot), inventorySlot);
                    if (weapon == null) return;
                    sprite = weapon.tool.weaponSpriteHand;
                }

                weaponRender.sprite = sprite;
            }
            else
            {
                leftHand.SetActive(true);
                weaponRender.sprite = null;
            }
            
            if (gun.CanUse())
            {
                gun.Use();
                gun.Reload();
            }
            else if (tool.CanUse())
            {
                tool.Use();
            }
            else if (inputManager.pressedAttack && !invetoryOpened && !craftingOpened)
            {
                playerAttack.StartSwinging();
                resourceSystem.DestroyResource(damage);
            }
        }
    }
    void OpenInventory()
    {
        if (!inputManager.pressedInventory || craftingOpened || OpenPauseMenu.pauseMenuOpen) return;
        invetoryOpened = !invetoryOpened;
        inventoryUI.SetActive(invetoryOpened);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void OpenCrafting()
    {
        if (!inputManager.pressedCrafting || invetoryOpened || OpenPauseMenu.pauseMenuOpen) return;
        craftingOpened = !craftingOpened;
        craftingUI.SetActive(craftingOpened);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public bool AllowedToScroll()
    {
        return !invetoryOpened && !craftingOpened && !OpenPauseMenu.pauseMenuOpen;
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

        itemName.text = inventory.items[inventorySlot].item == null ? $"" : $"{inventory.items[inventorySlot].item.itemName}";
    }
}
