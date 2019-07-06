using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapScript : MonoBehaviour
{
    public int damage = 10;

    public Sprite trigger;
    public Stats playerHealth;

    private SpriteRenderer stand;

    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        stand = GetComponent<SpriteRenderer>();
       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player") )
        {
            stand.sprite = trigger;

            playerHealth.TakeDamage(damage);
           
            Destroy(gameObject, 2);
        }
    }

}
