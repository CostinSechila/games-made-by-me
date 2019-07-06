using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelWatch : MonoBehaviour
{
    
    public TimeManager timeManager;

    private Movement playerMovement;


    //private Vector2 mouseInput;


    public void Start()
    {
        playerMovement = GetComponent<Movement>();
    }

    public void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(SlowTime());

           
        }

    }

    public IEnumerator SlowTime ()
    {
        timeManager.DoSlowMotion();
        playerMovement.movSpeed *= 3f;

        Debug.Log(Time.timeScale);

        yield return new WaitForSecondsRealtime(2);

        Debug.Log(Time.timeScale);

        playerMovement.movSpeed /= 3f;
        StartCoroutine(Reset());

        Debug.Log(Time.timeScale);
    }


    public IEnumerator Reset ()
    {
        timeManager.ResetTime();

        yield return null;
    }
    

    
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //if you select 2 blink to a point on the screen of choice in a certain area;


    //if you select 3 you gain invulnerability for 3 sec;


}
