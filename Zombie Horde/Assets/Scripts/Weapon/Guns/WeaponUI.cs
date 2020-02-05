using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image weaponSprite;
    [SerializeField] private Text weaponName, bullets, movementSpeed, fireRate, reloadTime;
    
    private Player player;

    private void Awake()
    {
        //player = GameManager.playerObject.GetComponent<Player>();
    }

    private void Update()
    {
        /*weaponSprite.sprite = player.weapon.uiSprite;
        weaponName.text = $"{player.weapon.weaponName}";
        bullets.text = player.weapon.weaponType.Equals(WeaponType.MELEE) ? $"N/A" : $"{player.weapon.bulletsInChamber}";
        movementSpeed.text = $"Move speed: {player.weapon.movementSpeed}";
        fireRate.text = $"{(player.weapon.weaponType.Equals(WeaponType.MELEE) ? "Attack speed" : "RPM")}: {player.weapon.weaponSpeed}";
        reloadTime.text = player.weapon.weaponType.Equals(WeaponType.MELEE) ? $"Reload time: N/A" : $"Reload time: {player.weapon.reloadSpeed}";*/
    }
}
