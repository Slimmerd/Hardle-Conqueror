using UnityEngine;

public class weapons
{
    public float FireRate;
    public float FireSpread;
    public Vector2 FireRecoil = Vector2.zero;
    public float damage;
    public float bulletSpeed;
    
    
    public weapons(float fireRate, float fireSpread, float damage, Vector2 fireRecoil, float bulletSpeed)
    {
        this.FireRate = fireRate;
        this.FireSpread = fireSpread;
        this.damage = damage;
        this.FireRecoil = fireRecoil;
        this.bulletSpeed = bulletSpeed;
    }
}




public static class Gun
{
   public static readonly weapons PlayerPistol = new weapons(5, 1, 50, new Vector2(0.05f, 0.1f), 20);
   public static readonly weapons EnemyPistol = new weapons(1, 1, 25, new Vector2(0, 0), 20);
   
   public static readonly weapons PlayerShotGun = new weapons(3, 4, 50, new Vector2(0.5f, 1), 20);
   public static readonly weapons EnemyShotGun = new weapons(1, 3, 25, new Vector2(0, 0), 20);
   
}