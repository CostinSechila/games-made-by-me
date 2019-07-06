using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public int amount;

    private Attack playerAttack;

    public void Start()
    {
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            playerAttack.CollecAmmo(amount);
            DestroyAmmo();
        }
    }


    public void DestroyAmmo()
    {
        Destroy(gameObject, 1f);
    }
}
