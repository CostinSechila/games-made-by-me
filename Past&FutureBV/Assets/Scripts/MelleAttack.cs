using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelleAttack : MonoBehaviour
{
    public int damage = 20;


    public MeleeEnemy meleeEnemy;
    public EnemyScript rangeEnemy;
    public chestAnimation chest;

    public void Start()
    {
       // meleeEnemy = GameObject.FindGameObjectWithTag("MeleeEnemy").GetComponent<MeleeEnemy>();
       // rangeEnemy = GameObject.FindGameObjectWithTag("RangeEnemy").GetComponent<EnemyScript>();
        chest = GameObject.FindGameObjectWithTag("Chest").GetComponent<chestAnimation>();
    }

    public void OnTriggerEnter2D ( Collider2D other )
    {
        if ( other.CompareTag("Chest") )
        {
            chest.TakeDamage(damage);
        }

        //if ( other.CompareTag("MeleeEnemy"))
        //{
        //    meleeEnemy.TakeDamage(damage);
        //}
        //if ( other.CompareTag("RangeEnemy") )
        //{
        //    rangeEnemy.TakeDamage(damage);
        //}
    }


   
}
