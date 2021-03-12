using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Upgrade : MonoBehaviour
{
    int currency;
    int damage;
    int niszczenie;
    int speed;
    public Text coinsy;
    public Text damagetxt;
    public Text speedtxt;
    public Text niszczenietxt;

    void Start()
    {
        currency = PlayerPrefs.GetInt("currency");
        damage = PlayerPrefs.GetInt("damage",40);
        speed = PlayerPrefs.GetInt("speed",1);
        niszczenie = PlayerPrefs.GetInt("niszczenie");
    }
    
    void Update()
    {
        coinsy.text = "Coinsy: " + currency;
        damagetxt.text = "Damage: " + damage;
        speedtxt.text = "Speed: " + speed;
        if (niszczenie == 0)
        {
            niszczenietxt.text = "Niszczenie strzał: " + niszczenie;
        }
        else
        {
            niszczenietxt.text = "Upgrade wykorzystany";
        }

    }

    public void Plus_Damage()
    {
        damage = damage + 10;
        PlayerPrefs.SetInt("damage", damage);
        currency = currency - 5;
        PlayerPrefs.SetInt("currency", currency);
    }
    public void Minus_Damage()
    {
        damage = damage - 10;
        PlayerPrefs.SetInt("damage", damage);
        currency = currency - 1;
        PlayerPrefs.SetInt("currency", currency);
    }

    public void Plus_Speed()
    {
        speed = speed + 1;
        PlayerPrefs.SetInt("speed", speed);
        currency = currency - 5;
        PlayerPrefs.SetInt("currency", currency);
    }
    public void Minus_Speed()
    {
        speed = speed - 1;
        PlayerPrefs.SetInt("speed", speed);
        currency = currency - 1;
        PlayerPrefs.SetInt("currency", currency);
    }
    public void Plus_Strzalki()
    {
        if (niszczenie == 0)
        {
            niszczenie = niszczenie + 1;
            PlayerPrefs.SetInt("niszczenie", niszczenie);
            currency = currency - 100;
            PlayerPrefs.SetInt("currency", currency);
        }
       
    }
    public void Minus_Strzalki()
    {
        if (niszczenie == 1)
        {
            niszczenie = niszczenie - 1;
            PlayerPrefs.SetInt("niszczenie", niszczenie);
            currency = currency - 1;
            PlayerPrefs.SetInt("currency", currency);
        }
    }

}
