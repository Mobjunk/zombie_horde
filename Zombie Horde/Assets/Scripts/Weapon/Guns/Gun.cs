using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Gun : Weapon<GunData>
{
    /// <summary>
    /// The current time of the reload
    /// </summary>
    private float reloadTimer;
    /// <summary>
    /// Time between each possible shot
    /// </summary>
    public float _cooldownRatePerBulletShot;
    /// <summary>
    /// Time when a new bullet can be fired again
    /// </summary>
    private float _newBulletTimeStamp;

    public Gun(Player player) : base(player)
    {
        _newBulletTimeStamp = Time.time;
    }
    
    public override bool CanUse()
    {
        var weapon = Get(GetWeapon(player.inventorySlot), player.inventorySlot);
        if (weapon == null)
        {
            foreach (var gun in player.guns.Where(gun => gun != null).Where(gun => gun.reloading))
                ResetReload(gun);

            return false;
        }

        _cooldownRatePerBulletShot = 1.0f / weapon.gun.weaponSpeed;

        return true;
    }
    
    public override void Use()
    {
        if (!inputManager.pressedAttack || player.inventoryOpened || player.craftingOpened) return;
        
        var weapon = Get(GetWeapon(player.inventorySlot), player.inventorySlot);
        if (weapon == null || weapon.reloading) return;

        if (weapon.bulletsInChamber <= 0)
        {
            ToolTipSystem.showReload = true;
            return;
        }

        if (Time.time > _newBulletTimeStamp)
        {
            weapon.gunDurability -= weapon.gun.durabilityDamage;
        
            if (weapon.gunDurability <= 0)
            {
                player.inventory.Remove(weapon.gun.item.itemId, 1, player.inventorySlot);
                player.guns.Remove(weapon);
            }
        
            weapon.bulletsInChamber--;
            SpawnBullet(weapon.gun);
            
            _newBulletTimeStamp = Time.time + _cooldownRatePerBulletShot;
        }
    }

    public override float GetDamage()
    {
        var weapon = Get(GetWeapon(player.inventorySlot), player.inventorySlot);
        if (weapon == null) return 0;
        return weapon.gun.weaponDamage;
    }

    public override GunData GetWeapon(int slot)
    {
        var selectedItem = player.inventory.Get(slot);
        if (selectedItem == null || selectedItem.item == null || selectedItem.item.gun == null) return null;

        if(!WeaponExists(selectedItem.item.gun, slot))
            player.guns.Add(new Guns(selectedItem.item.gun, slot));
        
        return selectedItem.item.gun;
    }

    public override bool WeaponExists(GunData gun, int slot)
    {
        return player.guns.Where(weapon => weapon != null && weapon.gun != null).Any(weapon => weapon.gun.Equals(gun) && weapon.slot == slot);
    }

    void SpawnBullet(GunData gun, int totalBullets = 1)
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
        var weapon = Get(GetWeapon(player.inventorySlot), player.inventorySlot);
        if (weapon == null) return;
        var gun = weapon.gun;

        if (weapon.bulletsInChamber >= gun.maxBullets || GetBulletAmount(gun) <= 0) return;

        if (!weapon.reloading && (inputManager.pressedReload && !player.inventoryOpened)) weapon.reloading = true;

        if (!weapon.reloading) return;
        
        var opacity = -(1 - (1 / gun.reloadSpeed) * reloadTimer) + 1;

        SetBulletOpacity(player.inventorySlot, opacity);
        
        reloadTimer += Time.deltaTime;
        if (!(reloadTimer >= gun.reloadSpeed)) return;
        
        var ammoAmount = gun.maxBullets - weapon.bulletsInChamber;
        if (ammoAmount > GetBulletAmount(gun)) ammoAmount = GetBulletAmount(gun);

        player.inventory.Remove(gun.bullets.itemId, ammoAmount);
        weapon.bulletsInChamber += ammoAmount;
        ResetReload(weapon);
    }
    
    private void ResetReload(Guns gun)
    {
        reloadTimer = 0;
        gun.reloading = false;
        SetBulletOpacity(gun.slot);
    }

    private void SetBulletOpacity(int invSlot, float opacity = 1f)
    {
        var slot = inventoryHotbar.transform.GetChild(invSlot);
        var canvas = slot.GetChild(0);
        var itemSprite = canvas.GetChild(0);
        var bullets = itemSprite.GetChild(1);

        for (var index = 0; index < 3; index++)
        {
            var image = bullets.GetChild(index).GetComponent<Image>();
            var color = image.color;
            color = new Color(color.r, color.g, color.b, opacity);
            image.color = color;
        }
    }

    private int GetBulletAmount(GunData gun)
    {
        return player.inventory.GetAmountFromItem(gun.bullets.itemId);
    }
    
    public Guns Get(GunData gun, int slot)
    {
        return player.guns.Where(weapon => weapon != null && weapon.gun != null).FirstOrDefault(weapon => weapon.gun.Equals(gun) && weapon.slot == slot);
    }
}