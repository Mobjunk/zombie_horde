using UnityEngine;

public class WeaponData : ScriptableObject
{
    [Header("Weapon Data")]
    public WeaponType weaponType;
    public Sprite uiSprite;
    public Sprite weaponSprite;
    public string weaponName;
    public float weaponSpeed;
    public float movementSpeed;
    public bool twoHanded;
    public float weaponDurability;
    public float weaponDamage;
}

public enum WeaponType
{
    MELEE,
    RANGED
}

public enum ResourceType
{
    WOOD,
    STONE
}
