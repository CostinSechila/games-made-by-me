using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;

    public float speed;

    public GameObject effect;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if ( transform.position.x < -40 )
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player"))
        {


            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
            Destroy(gameObject);

            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
}
