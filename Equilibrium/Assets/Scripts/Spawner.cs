using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Color color;

    public GameObject platform;
    public Rigidbody rb;

    


    public int direction = 0;

    private Vector3 spawnPosition;
    private Vector3 endPosition;
    


    public float travelDistance = 30;
    public float travelSpeed = 200;
    public float YIncrement = 1;

    

    
    public void Awake()
    {
        spawnPosition = new Vector3(-15, 1, 0f);
        Debug.Log(spawnPosition);
        endPosition = new Vector3(15, 1, 0f);
        Debug.Log(endPosition);

    }


    IEnumerator MoveObject()
    {
        platform.transform.position = Vector3.Lerp(spawnPosition, endPosition, travelSpeed);
        Debug.Log("corutina a inceput");
        
        yield return new WaitForSecondsRealtime(0.2f);
    }

    public void SpawnObject()
    {
        GenerateObject();
        StartCoroutine("MoveObject");
        Instantiate(platform, spawnPosition, Quaternion.identity);
    }

    public void GenerateObject()
    {
        float x = Random.Range(3, 9);
        float z = Random.Range(3, 9);

        if (direction == 0)
        {
            spawnPosition = new Vector3(-15, YIncrement, 0f);
            endPosition = new Vector3(15, YIncrement, 0f);
            
        }
        else if (direction == 1)
        {
            spawnPosition = new Vector3(0f, YIncrement, 15);
            endPosition = new Vector3(0f, YIncrement, -15);
            
        }

        
        Vector3 scaleVector = new Vector3(x, 1, z);
        rb.mass = (x + z) / 2;

        platform.transform.localScale = scaleVector;

        YIncrement++;

    }

}
