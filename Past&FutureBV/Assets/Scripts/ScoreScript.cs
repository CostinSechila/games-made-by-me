using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public PointTracker points;

    public Text txt;

    public GameObject point;

    public void Start()
    {
        points = GameObject.FindGameObjectWithTag("Player").GetComponent<PointTracker>();
        txt = GetComponent<Text>();
        
    }


    public void Update()
    {
        txt.text = points.score.ToString();
    }
}
