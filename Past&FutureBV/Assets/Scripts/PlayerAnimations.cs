using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator playerAnim;
    private SpriteRenderer spriteRen;
    private Stats playerStats;
    private Attack playerRangeAttack;

    private Vector2 mousePos;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
        playerStats = GetComponent<Stats>();
        playerRangeAttack = GetComponent<Attack>();
    }

   
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;
        mousePos = mousePos.normalized;
        
        if ( playerStats.GetHealth() <= 0 )
        {
            playerAnim.SetBool("isDead", true);
        }

        if (playerRangeAttack.isAttacking == true)
        {

            if (mousePos.x <= 0)
            {
                spriteRen.flipX = false;
                playerAnim.SetBool("isAttackingRight", true);


            }
            else
            {
                spriteRen.flipX = true;
                playerAnim.SetBool("isAttackingRight", true);

            }
            
            if (mousePos.y > 0)
            {
                playerAnim.SetBool("isAttackingUp", true);
            }
           
            if (mousePos.y < 0)
            {
                playerAnim.SetBool("isAttackingDown", true);
            }
            

        }
        



        if ( Input.GetKey(KeyCode.W) )
        {
            playerAnim.SetBool("isWalkingUp", true);
           
        }
        else
        {
            playerAnim.SetBool("isWalkingUp", false);
        }
        


        if ( Input.GetKey(KeyCode.S) )
        {
            playerAnim.SetBool("isWalkingDown", true);

        }
        else
        {
            playerAnim.SetBool("isWalkingDown", false);
        }


        if ( Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) )
        {
            playerAnim.SetBool("isWalkingRight", true);
            if ( Input.GetKey(KeyCode.A) )
            {
                spriteRen.flipX = true;
            }
            else
            {
                spriteRen.flipX = false;

            }
        }
        else
        {
            playerAnim.SetBool("isWalkingRight", false);
        }
       

    }
}
