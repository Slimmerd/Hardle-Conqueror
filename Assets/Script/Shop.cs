using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static int money;
    public static int pistol = 1;
    public static int shotgun;
    private int _shotgunboguht;
    private int shotgunPrice = 3500;
    private int _healthPrice = 500;
    public static int _curntHealth = 100;
    private bool _buySucceed;

    public Button BuyButton;
    public Button buyShotGun;
    public Button pistolGun;
    public GameObject ShopMenu;

    public void Start()
    {
        // PlayerPrefs.DeleteAll();
        if (ShopMenu.activeInHierarchy == true)
        {
            GameObject.Find("Health").GetComponent<TextMeshProUGUI>().text =
                "Health:" + Mathf.RoundToInt(_curntHealth);
            GameObject.Find("MoneyT").GetComponent<TextMeshProUGUI>().text =
                "" + Mathf.RoundToInt(money) + "$";
        }

        money = PlayerPrefs.GetInt("money", money);
        pistol = PlayerPrefs.GetInt("pistol", pistol);
        shotgun = PlayerPrefs.GetInt("shotgun", shotgun);
        _shotgunboguht = PlayerPrefs.GetInt("shotgunboguht", _shotgunboguht);
        _healthPrice = PlayerPrefs.GetInt("healthPrice", _healthPrice);
        _curntHealth = PlayerPrefs.GetInt("curntHealth", _curntHealth);
    }


    public void Update()
    {
        //Checks
        if (ShopMenu.activeInHierarchy == true)
        {
            GameObject.Find("MoneyT").GetComponent<TextMeshProUGUI>().text =
                "" + Mathf.RoundToInt(money) + "$";

            GameObject.Find("Health").GetComponent<TextMeshProUGUI>().text =
                "Health:" + Mathf.RoundToInt(_curntHealth);


            //Buying ShotGun
            if (_shotgunboguht == 0)
            {
                GameObject.Find("ShotgunT").GetComponent<TextMeshProUGUI>().text =
                    "" + Mathf.RoundToInt(shotgunPrice);
                GameObject.Find("PistolT").GetComponent<TextMeshProUGUI>().text =
                    "Selected";
            }

            if (_shotgunboguht == 1 && pistol == 0 && shotgun == 1)
            {
                GameObject.Find("ShotgunT").GetComponent<TextMeshProUGUI>().text =
                    "Selected";
                GameObject.Find("PistolT").GetComponent<TextMeshProUGUI>().text =
                    "Select";
            }

            if (_shotgunboguht == 1 && pistol == 1 && shotgun == 0)
            {
                GameObject.Find("ShotgunT").GetComponent<TextMeshProUGUI>().text =
                    "Select";
                GameObject.Find("PistolT").GetComponent<TextMeshProUGUI>().text =
                    "Selected";
            }

            if (pistol == 1 && shotgun == 0)
            {
                pistolGun.interactable = false;
                buyShotGun.interactable = true;
            }
            else if (pistol == 0 && shotgun == 1)
            {
                pistolGun.interactable = true;
                buyShotGun.interactable = false;
            }


            //Buying Health
            if (BuyButton.interactable == true)
            {
                GameObject.Find("HealthT").GetComponent<TextMeshProUGUI>().text =
                    "" + Mathf.RoundToInt(_healthPrice);
            }

            if (_curntHealth == 500)
            {
                BuyButton.interactable = false;
                GameObject.Find("HealthT").GetComponent<TextMeshProUGUI>().text =
                    "Full";
            }

            if (_curntHealth == 100)
            {
                BuyButton.interactable = true;
                _healthPrice = 500;
            }
        }
    }


    //Guns
    public void BuyShotGun()
    {
        if (_shotgunboguht == 0 && money >= shotgunPrice)
        {
            Buy(shotgunPrice);
            _shotgunboguht = 1;
            GunSelect();
        }
        else
        {
            GunSelect();
        }
    }

    public void GunSelect()
    {
        if (_shotgunboguht == 1 && pistol == 1)
        {
            pistol = 0;
            shotgun = 1;
            pistolGun.interactable = true;
            buyShotGun.interactable = false;
        }
        else
        {
            shotgun = 0;
            pistol = 1;
            pistolGun.interactable = false;
            buyShotGun.interactable = true;
        }
    }

    //Health
    public void BuyHealth()
    {
        if (_curntHealth == 100 && money >= 500)
        {
            BuyButton.interactable = true;
            _curntHealth = 200;
            // MoveContrl.health = 200;
            _healthPrice = 1500;
            Buy(500);
        }
        else if (_curntHealth == 200 && money >= 1500)
        {
            BuyButton.interactable = true;
            _curntHealth = 350;
            // MoveContrl.health = 350;
            _healthPrice = 3500;
            Buy(1500);
        }
        else if (_curntHealth == 350 && money >= 3500)
        {
            BuyButton.interactable = true;
            _curntHealth = 500;
            // MoveContrl.health = 500;

            Buy(3500);

            BuyButton.interactable = false;
        }
    }

    //Other important functions
    public void ResetF()
    {
        money = 0;
        _curntHealth = 100;
        pistol = 1;
        shotgun = 0;
        _shotgunboguht = 0;
    }

    private void Buy(int expense)
    {
        if (money >= expense)
        {
            money -= expense;
        }
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("pistol", pistol);
        PlayerPrefs.SetInt("shotgun", shotgun);
        PlayerPrefs.SetInt("shotgunboguht", _shotgunboguht);
        PlayerPrefs.SetInt("healthPrice", _healthPrice);
        PlayerPrefs.SetInt("curntHealth", _curntHealth);

        PlayerPrefs.Save();
    }
}