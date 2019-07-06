using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;

    public int damage = 20;

    public Vector2 mouseInput;
    public Vector3 mousePos;

    private Vector2 target;

    private EnemyScript rangeEnemy;
    private MeleeEnemy meleeEnemy;
    public GameObject chest;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;
        //mousePos = mouseInput.normalized;
        //mousePos = mousePos.normalized;
        //mousePos.z = 0;

        if (GameObject.FindGameObjectWithTag("RangeEnemy"))
        {
            rangeEnemy = GameObject.FindGameObjectWithTag("RangeEnemy").GetComponent<EnemyScript>();
        }

        if (GameObject.FindGameObjectWithTag("MeleeEnemy"))
        {
            meleeEnemy = GameObject.FindGameObjectWithTag("MeleeEnemy").GetComponent<MeleeEnemy>();
        }

        DestroyBullet();
    }

    // Update is called once per frame
    void Update()

    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector2.Distance (transform.position, target)  < 0.2f )
        {
            DestroyBullet();
        }

        //transform.position += mousePos * speed * Time.deltaTime;

       
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag ("RangeEnemy") )
        {
            rangeEnemy.TakeDamage(damage);
            DestroyBullet();

            Debug.Log("hit");
            Debug.Log(rangeEnemy.GetHealth());
        }

        if (collision.CompareTag ("MeleeEnemy") )
        {
            meleeEnemy.TakeDamage(damage);
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        Destroy(gameObject, 1.5f);
    }



}
