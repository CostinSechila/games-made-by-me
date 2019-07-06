using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public Transform player;

    private PlayerController plHealth;

    public void Start()
    {
        plHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    public void LateUpdate()
    {
        if (plHealth.health > 0)
        {
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
        }
       

    }

}
