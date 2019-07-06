using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private PlayerController player;



    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();


        waitTime = startWaitTime;

        moveSpot.position = new Vector3(Random.Range(minX, maxX), 1.0f, Random.Range(minZ, maxZ));
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if ( Vector3.Distance( transform.position, moveSpot.position) < 0.1f )
        {
            if ( waitTime <= 0 )
            {
                moveSpot.position = new Vector3(Random.Range(minX, maxX), 1.0f, Random.Range(minZ, maxZ));
                waitTime = startWaitTime;

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (player.health <= 0 )
        {
            Destroy(gameObject);
        }
    }



}
