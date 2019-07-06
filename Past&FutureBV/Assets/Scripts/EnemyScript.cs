using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float movSpeed = 5f;

    private int health = 30;

    public float stoppingDistance = 0.2f;
    public float retreatDistance = 0.3f;

    private float timeBtwShots = 2 ;
    public float startTimeBtwShots ;


    private Transform player;
    public GameObject projectile;

    public RecoverHealthItem recovHealth;
    public SpeedBoostItem speedBoostItem;
    public GameObject point;

    private Stats playerStats;
    private PointTracker playerPoints;

    public bool isAttacking = false;

    public int GetHealth()
    {
        return health;
    }

    public void Start()
    {
        playerPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<PointTracker>();
        

        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
    }

    public void Update()
    {

        if (playerStats.GetHealth() >= 0)
        {
            if (Vector2.Distance(transform.position, player.position) >= stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, movSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -movSpeed * Time.deltaTime);
            }
        }
        //Instantiate(projectile, transform.position, Quaternion.identity);

        if (timeBtwShots <= 0)
        {
            isAttacking = true;
            //Instantiate projectile
            Instantiate(projectile, transform.position, Quaternion.identity);

            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        
        

    }

    //public void OnTriggerEnter2D (Collider2D other)
    //{
    //    if ( other.CompareTag("Bullet") )
    //    {
    //        health -= 5;
    //    }
    //}

    public void Die ()
    {
        playerPoints.score++;

        int number = Random.Range(1, 11);

        if ( number < 3 )
        {
            
            Instantiate (recovHealth, transform.position, Quaternion.identity);
        }
        else if ( number > 4 && number < 7)
        {
            
            Instantiate (speedBoostItem, transform.position, Quaternion.identity);
        }
        else if ( number == 3 || number ==10)
        {
            Instantiate(point, transform.position, Quaternion.identity);
        }

        gameObject.SetActive(false);
        Debug.Log(gameObject);
    }

    public void TakeDamage (int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }


    }
}
