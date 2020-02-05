using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Weapon
{
    /// <summary>
    /// the game manager of the game
    /// </summary>
    private GameManager gameManager => GameManager.instance;
    /// <summary>
    /// The input system for the player
    /// </summary>
    private InputManager inputManager => InputManager.instance;
    /// <summary>
    /// The player of the weapons
    /// </summary>
    private Player player;
    /// <summary>
    /// The current time of the reload
    /// </summary>
    private float reloadTimer;
    /// <summary>
    /// A list of all the weapons the player has
    /// </summary>
    private List<Weapons> weapons = new List<Weapons>();
    
    public Weapon(Player player)
    {
        this.player = player;
    }
    
    public bool Shoot()
    {
        if (!inputManager.pressedAttack || player.invetoryOpened || player.craftingOpened) return true;

        var weapon = GetWeapon(GetGun());
        if (weapon == null || weapon.reloading) return false;

        if (weapon.bulletsInChamber <= 0) return true;
        
        weapon.bulletsInChamber--;
        SpawnBullet(weapon.gun);

        return true;
    }

    public void SpawnBullet(GunData gun, int totalBullets = 1)
    {
        var forward = player.transform.forward;
        for (int index = 0; index < totalBullets; index++)
        {
            var bulletObject = MonoBehaviour.Instantiate(gameManager.bulletPrefab, gameManager.bulletSpawnLocation.position, Quaternion.LookRotation(forward));
            var bullet = bulletObject.GetComponent<Bullet>();
            bullet.Initialize(gun);
        }
    }

    public void Reload()
    {
        var weapon = GetWeapon(GetGun());
        if (weapon == null) return;
        var gun = weapon.gun;

        if (weapon.bulletsInChamber >= gun.maxBullets || GetBulletAmount(gun) <= 0) return;

        if (!weapon.reloading && (inputManager.pressedReload && !player.invetoryOpened)) weapon.reloading = true;

        if (!weapon.reloading) return;
        
        reloadTimer += Time.deltaTime;
        if (!(reloadTimer >= gun.reloadSpeed)) return;
        
        var ammoAmount = gun.maxBullets - weapon.bulletsInChamber;
        if (ammoAmount > GetBulletAmount(gun)) ammoAmount = GetBulletAmount(gun);

        player.inventory.Remove(gun.bullets.itemId, ammoAmount);
        weapon.bulletsInChamber += ammoAmount;
        ResetReload(weapon);
    }

    public GunData GetGun()
    {
        var selectedItem = player.inventory.Get(player.inventorySlot);
        if (selectedItem == null || selectedItem.item == null) return null;
        
        if(!WeaponExists(selectedItem.item.gun))
            weapons.Add(new Weapons(selectedItem.item.gun));
        
        return selectedItem.item.gun;
    }

    private bool WeaponExists(GunData gun)
    {
        return weapons.Where(weapon => weapon != null && weapon.gun != null).Any(weapon => weapon.gun.Equals(gun));
    }
    
    public Weapons GetWeapon(GunData gun)
    {
        return weapons.Where(weapon => weapon != null && weapon.gun != null).FirstOrDefault(weapon => weapon.gun.Equals(gun));
    }

    private int GetBulletAmount(GunData gun)
    {
        return player.inventory.GetAmountFromItem(gun.bullets.itemId);
    }
    
    private void ResetReload(Weapons weapon)
    {
        reloadTimer = 0;
        weapon.reloading = false;
    }
}