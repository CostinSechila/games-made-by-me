using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public PointTracker playerPoints;

    public AudioSource aud;

    public void Start()
    {
        playerPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<PointTracker>();
        aud = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aud.Play(0);
            playerPoints.score++;
            Destroy(gameObject, 1f);
        }
    }
}
