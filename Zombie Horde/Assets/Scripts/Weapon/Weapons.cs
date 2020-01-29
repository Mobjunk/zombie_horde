public class Weapons
{
    public GunData gun;
    public int bulletsInChamber;
    public bool reloading;

    public Weapons(GunData gun)
    {
        this.gun = gun;
        this.bulletsInChamber = 0;
        this.reloading = false;
    }
}