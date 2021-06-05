using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Upgrade : MonoBehaviour
{
    int currency;
    int damage=40;
    int niszczenie;
    int speed;
    int coins;
    int maxHealth;
    public Text coinsy;
    public Text damagetxt;
    public Text speedtxt;
    public Text niszczenietxt;
    public Text healthtxt;
    public GameObject UpgradeMenu;
    string wybor;
    int number;
    System.Random random = new System.Random();

    void Start()
    {
        currency = PlayerPrefs.GetInt("currency");
        damage = PlayerPrefs.GetInt("damage", 40);
        speed = PlayerPrefs.GetInt("speed", 1);
        niszczenie = PlayerPrefs.GetInt("niszczenie");
        maxHealth = PlayerPrefs.GetInt("maxHealth",100);
    }

    void Update()
    {
        healthtxt.text = "Health: " + maxHealth;
        coinsy.text = "Coinsy: " + currency;
        damagetxt.text = "Damage: " + damage;
        speedtxt.text = "Speed: " + speed;

        if (niszczenie == 0)
        {
            niszczenietxt.text = "Penetracja: " + niszczenie;
        }
        else
        {
            niszczenietxt.text = "Penetracja:1";
        }


    }

    public void Plus_Damage()
    {
        if (currency >= 10)
        {
            damage = damage + 10;
            PlayerPrefs.SetInt("damage", damage);
            currency = currency - 10;
            PlayerPrefs.SetInt("currency", currency);
        }
    }

    public void Plus_Speed()
    {
        if (currency >= 20)
        {
            speed = speed + 1;
            PlayerPrefs.SetInt("speed", speed);
            currency = currency - 20;
            PlayerPrefs.SetInt("currency", currency);
        }
    }
    public void Plus_Strzalki()
    {
        if (currency >= 30)
        {
            if (niszczenie == 0)
            {
                niszczenie = niszczenie + 1;
                PlayerPrefs.SetInt("niszczenie", niszczenie);
                currency = currency - 30;
                PlayerPrefs.SetInt("currency", currency);
            }
        }

    }
    public void Plus_Health()
    {
        if (currency >= 20)
        {
            maxHealth = maxHealth + 1;
            PlayerPrefs.SetInt("maxHealth", maxHealth);
            currency = currency - 20;
            PlayerPrefs.SetInt("currency", currency);
        }
    }

    public void Plus_Skin()
    {
        if (currency >= 500)
        {
            number = random.Next(1, 4);
            PlayerPrefs.SetInt("wybor", number);
            currency = currency - 1;
            PlayerPrefs.SetInt("currency", currency);
        }
    }
    public void CloseMenu()
    {
        UpgradeMenu.SetActive(false);
    }
}
