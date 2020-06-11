using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    private SoundManagement audioManager;
    public GameObject bulletPrefab;
    
    private float timeToFire = 0;
    private float FireSpreadAngle = 15;
    private int spread;
    private float attackDistance = 10;
   [Header("Player")] public Transform player;

    public weapons _weapons;
    private bool adead;

    void Start()
    {
        audioManager = SoundManagement.instance;
        if (gameObject.CompareTag("Player"))
        {
            if (gameObject.name == "PlayerPistol")
            {
                _weapons = Gun.PlayerPistol;
            }
            if (gameObject.name == "PlayerShotGun")
            {
                _weapons = Gun.PlayerShotGun;
            }
        }
        if (gameObject.CompareTag("Enemy"))
        {
            if (gameObject.name == "EnemyPistol")
            {
                _weapons = Gun.EnemyPistol;
            }
        }
    }

    void Update() //FireRate function
    {
       
        
        
        
        if (gameObject.CompareTag("Player"))
        {
            if (_weapons.FireRate == 0)
            {
                if (Input.GetButtonDown("Fire1") && MenuPause.GamePaused == false)
                {
                    Shoot();
                    audioManager.PlaySound("PistolSound"); //PlaySound
                }
            }
            else
            {
                if (Input.GetButton("Fire1") && Time.time > timeToFire && MenuPause.GamePaused ==false)
                {
                   
                        timeToFire = Time.time + 2 / _weapons.FireRate;
                        SpreadE();
                        //  Shoot();
                        // audioManager.PlaySound("PistolSound");
                    
                }
            }
        }

        if (gameObject.CompareTag("Enemy") && Time.time > timeToFire && MoveContrl.Pdead == false && adead == false)
        {
            Enemy enemy = GetComponentInParent<Enemy>();
            adead = enemy._edead;
            
            if ((Vector2.Distance(transform.position, player.position) < attackDistance)&&adead ==false)
            {
                timeToFire = Time.time + 2 / _weapons.FireRate;
                SpreadE();
            }
        }
    }

    public void SpreadE()
    {
        for (int i = 0; i < _weapons.FireSpread; i++)
        {
            Shoot();
            audioManager.PlaySound("PistolSound");
        }
    }


    void Shoot()
    {
        if (_weapons.FireSpread > 1)
        {
            spread = (int) Random.Range(-FireSpreadAngle, FireSpreadAngle);
        }
        else spread = (int) Random.Range(0, 0);

        Quaternion gay = Quaternion.Euler(0, 0, spread);
        if (gameObject.CompareTag("Player"))
        {
            transform.root.GetComponent<MoveContrl>().FireRecoil = _weapons.FireRecoil;
            StartCoroutine(FireRec());
        }
       

        //Prefab shooting
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * gay);
    }

    public IEnumerator FireRec()
    {
        yield return new WaitForSeconds(0.15f);
        transform.root.GetComponent<MoveContrl>().FireCap();
        yield return 0;
    }
}