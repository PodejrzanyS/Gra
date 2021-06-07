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
    SpriteRenderer sr;
    System.Random random = new System.Random();

    void Start()
    {
        currency = PlayerPrefs.GetInt("currency",0);
        damage = PlayerPrefs.GetInt("damage", 40);
        speed = PlayerPrefs.GetInt("speed", 4);
        niszczenie = PlayerPrefs.GetInt("niszczenie",0);
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
        if (currency >= 1)
        {
            damage = damage + 1;
            PlayerPrefs.SetInt("damage", damage);
            currency = currency - 10;
            PlayerPrefs.SetInt("currency", currency);
        }
    }

    public void Plus_Speed()
    {
        if (currency >= 1)
        {
            speed = speed + 1;
            PlayerPrefs.SetInt("speed", speed);
            currency = currency - 1;
            PlayerPrefs.SetInt("currency", currency);
        }
    }
    public void Plus_Strzalki()
    {
        if (currency >= 1)
        {
            if (niszczenie == 0)
            {
                niszczenie = niszczenie + 1;
                PlayerPrefs.SetInt("niszczenie", niszczenie);
                currency = currency - 1;
                PlayerPrefs.SetInt("currency", currency);
            }
        }

    }
    public void Plus_Health()
    {
        if (currency >= 1)
        {
            maxHealth = maxHealth + 1;
            PlayerPrefs.SetInt("maxHealth", maxHealth);
            currency = currency - 1;
            PlayerPrefs.SetInt("currency", currency);
        }
    }

    public void Plus_Skin()
    {
        if (currency >= 1)
        {
            number = random.Next(1, 8);
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
