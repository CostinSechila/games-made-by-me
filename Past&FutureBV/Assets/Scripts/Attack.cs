using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int meleeAttack = 25;
    public int rangeAttack = 75;

    //public bool isInMeleeRange = false;


    public int ammo = 10;
  
    public bool isAttacking = false;

    public int Test = 0;

    public GameObject Bullet;

    private AudioSource aud;
    

    public void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if ( Input.GetKeyDown(KeyCode.R) )
        {
            Debug.Log("rrreload");
            ammo += 50;
        }

        if ( Input.GetMouseButtonDown(1))
        {
            if (ammo != 0)
            {
                RangeAttack();
                ammo--;
            }
            
        }
        else
        {
            isAttacking = false;
        }

        if ( ammo == 0 )
        {
            //Debug.Log("Out of ammo");
           
        }
       
    }


    

    public void RangeAttack ()
    {
        aud.Play(0);


        isAttacking = true;
        Instantiate(Bullet, transform.position, Quaternion.identity);

        
      
    }

    public void CollecAmmo(int amount)
    {
        ammo += amount;
    }

}
