using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    public WeaponData weapon;
    public Container inventory;
    public int inventorySlot = 0;

    private void Start()
    {
        inventory = new Container(36);
    }

    public void Add()
    {
        inventory.Add(2, 10);
        inventory.Add(0, 10);
    }

    public void Remove()
    {
        inventory.Remove(2, 2);
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            inventorySlot++;
            if (inventorySlot > 8) inventorySlot = 0;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
        {
            inventorySlot--;
            if (inventorySlot < 0) inventorySlot = 8;
        }
    }
}
