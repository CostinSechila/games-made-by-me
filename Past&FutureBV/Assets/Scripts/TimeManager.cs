using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.5f;
   

    // Update is called once per frame
    void Update()
    {

      
    }


    public void DoSlowMotion()
    {
        Time.timeScale = 0.3f;
       
    }

    public void ResetTime ()
    {
        Time.timeScale = 1f;
    }
}
