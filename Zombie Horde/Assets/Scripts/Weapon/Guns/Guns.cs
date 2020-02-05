public class Guns
{
    public GunData gun;
    public int bulletsInChamber;
    public bool reloading;
    public float gunDurability;

    public Guns(GunData gun)
    {
        this.gun = gun;
        this.bulletsInChamber = 0;
        this.reloading = false;
        this.gunDurability = gun.weaponDurability;
    }
}