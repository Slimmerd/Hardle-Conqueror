using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet : MonoBehaviour
{
    //public float bulletSpeed; //Bullet speed
 //   public int damage = 40; //Bullet damage
    
    public GameObject impactEffect;
    public Rigidbody2D rb;
    public weapons _weapons;
    // Start is called before the first frame update

    private void Awake()
    {
        if (gameObject.CompareTag("PlayerBullet"))
        {
            if (!string.IsNullOrEmpty(gameObject.name ="PlayerPistol"))
            {
                _weapons = Gun.PlayerPistol;
            }
            else if( !string.IsNullOrEmpty(gameObject.name ="PlayerShotGun"))
            {
                _weapons = Gun.PlayerShotGun;
            }
           
        }
        if (gameObject.CompareTag("EnemyBullet"))
        {
            _weapons = Gun.EnemyPistol;
        }
    }

    void Start()
    {
        //Bullets ignore itself 
        Physics2D.IgnoreLayerCollision(10, 10);
        Physics2D.IgnoreLayerCollision(12, 12);
        //Enemy's bullet ignores enemy's body and same for player
        Physics2D.IgnoreLayerCollision(9, 10);
        Physics2D.IgnoreLayerCollision(11, 12);

        rb.velocity = transform.right * _weapons.bulletSpeed;

        Destroy(gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //On hit different parts of body it takes damage
        if (hitInfo.CompareTag("Enemy"))
        {
            Enemy enemy = hitInfo.GetComponentInParent<Enemy>();
            enemy.TakeDamage(_weapons.damage);
        }

        if (hitInfo.CompareTag("EnemyHead"))
        {
            Enemy enemy = hitInfo.GetComponentInParent<Enemy>();
            enemy.TakeDamage(_weapons.damage*2);
        }

        if (hitInfo.CompareTag("Player"))
        {
            MoveContrl Player = hitInfo.GetComponentInParent<MoveContrl>();
            Player.TakeDamage(_weapons.damage*2);
        }


        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}