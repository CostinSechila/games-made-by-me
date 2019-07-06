using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    public Text scoreDisplay;

    public void Update()
    {
        scoreDisplay.text = score.ToString();
    }


    public void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Obstacle") )
        {
            score++;
            Debug.Log(score);
        }
    }
}
