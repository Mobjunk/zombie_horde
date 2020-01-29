using UnityEngine;

[CreateAssetMenu(fileName = "New gun", menuName = "Gun")]
public class GunData : WeaponData
{
    [Header("Gun Data")]
    public Item bullets;
    public int maxBullets;
    public float reloadSpeed;
    public float bulletMovementSpeed;
}
