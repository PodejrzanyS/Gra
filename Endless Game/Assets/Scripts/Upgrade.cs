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
    int speed;
    public Text coinsy;
    public Text damagetxt;
    public Text speedtxt;

    void Start()
    {
        currency = PlayerPrefs.GetInt("currency");
        damage = PlayerPrefs.GetInt("damage");
        speed = PlayerPrefs.GetInt("speed",1);
    }
    
    void Update()
    {
        coinsy.text = "Coinsy: " + currency;
        damagetxt.text = "Damage: " + damage;
        speedtxt.text = "Speed: " + speed;

    }

    public void Plus_Damage()
    {
        damage = damage + 10;
        PlayerPrefs.SetInt("damage", damage);
        currency = currency - 1;
        PlayerPrefs.SetInt("currency", currency);
    }

    public void Plus_Speed()
    {
        speed = speed + 1;
        PlayerPrefs.SetInt("speed", speed);
        currency = currency - 1;
        PlayerPrefs.SetInt("currency", currency);
    }

}
