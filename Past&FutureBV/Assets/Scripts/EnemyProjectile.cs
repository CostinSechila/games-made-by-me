using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private int damage = 5;
    private float shotSpeed = 10f;

    private Transform target;
    private Stats playerStats;

    

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        

        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();

    }

    public void Update()
    {

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position , shotSpeed * Time.deltaTime);
        }



        if (target != null &&transform.position.x == target.position.x && transform.position.y == target.position.y )
        {
            DestroyProjectile();
        }


    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStats.TakeDamage(damage);

            Debug.Log(playerStats.GetHealth());

            DestroyProjectile();

        }
    }
  

    public void DestroyProjectile()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public int GetDamage()
    {
        return damage;
    }
}
