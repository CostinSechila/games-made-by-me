using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAnim : MonoBehaviour
{
    public Transform player;
    private Animator enemyAnim;

    private EnemyScript enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<EnemyScript>();

        enemyAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(!player)
        {
            Debug.Log("nu este transform");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.isAttacking == true)
        {
            if (player.position.y > transform.position.y)
            {
                enemyAnim.SetBool("isAttackingDown", true);
            }
            else
            {
                enemyAnim.SetBool("isAttakingUp", true);
            }

            if (player.position.y < transform.position.y)
            {
                enemyAnim.SetBool("isAttackingDown", true);
            }
            else
            {
                enemyAnim.SetBool("isAttakingUp", true);
            }
        }
    }
}
