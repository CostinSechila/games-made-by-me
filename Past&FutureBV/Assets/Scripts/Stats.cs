using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private int health = 100;

    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }




    public void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public int GetHealth ()
    {
        return health;
    }

    public void  RecoverHealth ( int amount )
    {
        health += amount;
    }


    public void TakeDamage( int damage )
    {
        health -= damage;
    }

    public void Die()
    {
        //  anim.SetBool("isDead", true);        
          //disable the colliders
          Destroy(gameObject,3);       

        //
    }


}
