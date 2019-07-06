using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private int health = 10;
    private int damage = 10;

    private float movSpeed = 2f;

    private float stoppingDistance = 0.2f;

    //private float timeBtwAttack = 2;
    //private float startTimeBtwAttack = 1;
    public bool isAttacking = false;

    private GameObject player;
    private Stats playerStats;
    private PointTracker playerPoints;
    public GameObject point;


    public RecoverHealthItem recovHealth;
    public SpeedBoostItem speedBoostItem;
    

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        playerPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<PointTracker>();
    }

    public void Update()
    {
        if (playerStats.GetHealth() > 0)
        {
            if (Vector2.Distance(transform.position, player.transform.position) >= stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movSpeed * Time.deltaTime);
            }
        }

        if (!isAttacking )
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 0.18f);

            foreach (Collider2D collider in  colliders)
            {
                if (collider.CompareTag("Player") )
                {
                    StartCoroutine(MeleeAttack());
                }

               
            }
        }

       if ( health <= 0 )
        {
            Die();
        }



    }

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if ( collision.CompareTag ("Bullet") )
    //    {
    //        TakeDamage(5);
    //    }
    //}


    public IEnumerator MeleeAttack ()
    {
        playerStats.TakeDamage(damage);
        isAttacking = true;

        yield return new WaitForSecondsRealtime(2);

        isAttacking = false;
        Debug.Log(playerStats.GetHealth());
        
    }

    public void TakeDamage ( int damage )
    {
        health -= damage;
    }

    public void Die ()
    {

        int number = Random.Range(1, 11);

        if (number < 3)
        {

            Instantiate(recovHealth, transform.position, Quaternion.identity);
        }
        else if (number > 4 && number < 7)
        {

            Instantiate(speedBoostItem, transform.position, Quaternion.identity);
        }
        else if (number == 9 && number == 10)
        {
            Instantiate(point, transform.position, Quaternion.identity);
        }



        playerPoints.score++;
        Destroy(gameObject);
    }

}
