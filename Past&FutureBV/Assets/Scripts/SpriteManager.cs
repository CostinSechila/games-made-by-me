using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public GameObject player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        SpriteRenderer[] renderes = FindObjectsOfType<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderes)
        {
            if (renderer.gameObject.layer == LayerMask.NameToLayer("map"))
            {
                renderer.sortingOrder = -1000;
            }
            else if (player != null)
            {
                renderer.sortingOrder = (int)((renderer.transform.position.y - player.transform.position.y) * -300);

            }
        }
    }
}
