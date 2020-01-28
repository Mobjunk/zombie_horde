using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public WeaponData weapon;
    public Container inventory;

    private void Awake()
    {
        inventory = new Container(36);
    }

    public void Add()
    {
        inventory.Add(0);
        foreach (var i in inventory.items)
        {
            if (i == null) continue;
            
            print($"itemName: {i.item.itemName}");
        }
    }

    public void Remove()
    {
        inventory.Remove(1);
    }
}
