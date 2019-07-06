using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;

    public Vector2[] instPos;

    void Start()
    {

        StartCoroutine(reSpawn());
      

    }


    IEnumerator reSpawn()
    {
        for (int i = 0; i < instPos.Length; i++)
        {

            Instantiate(enemy, instPos[i], Quaternion.identity);
        }

        yield return new WaitForSecondsRealtime(30);
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
