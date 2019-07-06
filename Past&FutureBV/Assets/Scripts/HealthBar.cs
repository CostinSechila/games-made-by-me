using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image img;

    public Sprite[] imags;

    public Stats playerHealth;

    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        img = GetComponent<Image>();
    }

    public void Update()
    {
        UpdateHealthBar();
    }
    public void UpdateHealthBar ()
    {
        if ( playerHealth.GetHealth() >= 100 )
        {
            img.sprite = imags[20];
        }

        if ( playerHealth.GetHealth() == 95)
        {
            img.sprite = imags[19];
        }
        if (playerHealth.GetHealth() == 90)
        {
            img.sprite = imags[18];
        }
        if (playerHealth.GetHealth() == 85)
        {
            img.sprite = imags[17];
        }
        if (playerHealth.GetHealth() == 80)
        {
            img.sprite = imags[16];
        }
        if (playerHealth.GetHealth() == 75)
        {
            img.sprite = imags[15];
        }
        if (playerHealth.GetHealth() == 70)
        {
            img.sprite = imags[14];
        }
        if (playerHealth.GetHealth() == 65)
        {
            img.sprite = imags[13];
        }
        if (playerHealth.GetHealth() == 60)
        {
            img.sprite = imags[12];
        }
        if (playerHealth.GetHealth() == 55)
        {
            img.sprite = imags[11];
        }
        if (playerHealth.GetHealth() == 50)
        {
            img.sprite = imags[10];
        }
        if (playerHealth.GetHealth() == 45)
        {
            img.sprite = imags[9];
        }
        if (playerHealth.GetHealth() == 40)
        {
            img.sprite = imags[8];
        }
        if (playerHealth.GetHealth() == 35)
        {
            img.sprite = imags[7];
        }
        if (playerHealth.GetHealth() == 30)
        {
            img.sprite = imags[6];
        }
        if (playerHealth.GetHealth() == 25)
        {
            img.sprite = imags[5];
        }
        if (playerHealth.GetHealth() == 20)
        {
            img.sprite = imags[4];
        }
        if (playerHealth.GetHealth() == 15)
        {
            img.sprite = imags[3];
        }
        if (playerHealth.GetHealth() == 10)
        {
            img.sprite = imags[2];
        }
        if (playerHealth.GetHealth() == 5)
        {
            img.sprite = imags[1];
        }
        if (playerHealth.GetHealth() == 0)
        {
            img.sprite = imags[0];
        }





    }
}
