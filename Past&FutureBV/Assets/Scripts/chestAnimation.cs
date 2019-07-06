using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestAnimation : MonoBehaviour
{
    public int health = 4;

    private Animator chestAnim;
    private MelleAttack plAttack;
    

    public void Start()


    {
        plAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<MelleAttack>();

        chestAnim = GetComponent<Animator>();
    }


    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") )
        {
            chestAnim.SetBool("isHit", true);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Die ()
    {
       
        
            chestAnim.SetBool("isDead", true);
        
    }



}
