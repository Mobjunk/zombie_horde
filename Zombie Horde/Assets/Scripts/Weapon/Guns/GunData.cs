using UnityEngine;

[CreateAssetMenu(fileName = "New gun", menuName = "Gun")]
public class GunData : WeaponData
{
    [Header("Gun Data")]
    public int bulletsInChamber;
    public int bulletsInInventory;
    public float reloadSpeed;
}
