using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject playerObject, inventoryUI;
    private Player player;

    public void Start()
    {
        player = playerObject.GetComponent<Player>();
    }

    private void Update()
    {
        player.inventory.UpdateUI(new GameObject[] { inventoryUI });
    }
}
