using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float boostAmount = 1;

    private AudioSource aud;

    public void Start()
    {
        aud = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            aud.Play(0);

            Destroy(gameObject);
        }
    }





}
