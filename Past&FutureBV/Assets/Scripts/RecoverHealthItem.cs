using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverHealthItem : MonoBehaviour
{
    private int healthToRecover = 20;

    private Stats playerStats;

    public void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            recoverHealth();
            Destroy(gameObject);
        }
    }


    public void recoverHealth()
    {
        playerStats.RecoverHealth(healthToRecover);
        Debug.Log(playerStats.GetHealth());
    }
}
