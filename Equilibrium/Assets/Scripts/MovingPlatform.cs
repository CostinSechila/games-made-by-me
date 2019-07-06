using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    public static MovingPlatform CurrentPlatform { get; private set; }
   // public static MovingPlatform LastPlatform { get;  set; }

  

    //public Text gameOver;
    
    public int direction = 1;
    

    public bool isGrounded = false;
    public bool hasFallen = false;

    public bool hasReachedEnd = false;
    public bool hasReachedStart = true;

    public void OnEnable()
    {
        //if (LastPlatform == null)
        //{
        //    LastPlatform = GameObject.Find("cube").GetComponent<MovingPlatform>();
        //}
        //else
        //{
        //    lastplatform = currentplatform;
        //}
        CurrentPlatform = this;
    }
    
    public void Stop()
    {
        moveSpeed = 0f;
    }

    void Update()
    {
        Move();
       // SpawnPlatform();

    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
           
            isGrounded = true;
            Debug.Log("isgrounded true");
            if (CurrentPlatform.transform.position.y <= collision.transform.position.y - 0.1f  )
            {
                hasFallen = true;
                isGrounded = false;
                Debug.Log("isgrounded false, hasFallen true");
            }
            
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasFallen = true;  
            
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Platform") )
        {
            hasFallen = true;
            isGrounded = false;
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Platform") )
        {
            isGrounded = true;
        }
        if ( collision.gameObject.CompareTag("Ground") )
        {
            hasFallen = true;
        }
    }


    public void Move()
    {
        if (direction == 1)
        {
            if (hasReachedEnd == false && hasReachedStart == true)
            {

                transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * moveSpeed;
                if (CurrentPlatform.transform.position.x >= 15)
                {
                    hasReachedEnd = true;
                    hasReachedStart = false;
                }
            }
            if (hasReachedStart == false && hasReachedEnd == true)
            {
                transform.position -= new Vector3(1f, 0f, 0f) * Time.deltaTime * moveSpeed;
                if (CurrentPlatform.transform.position.x <= -15)
                {
                    hasReachedStart = true;
                    hasReachedEnd = false;
                }
            }
        }
        
        //if (direction == 2)
        //{
        //    if (hasReachedEnd == false && hasReachedStart == true)
        //    {

        //        transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime * moveSpeed;
        //        if (CurrentPlatform.transform.position.z <= -15)
        //        {
        //            hasReachedEnd = true;
        //            hasReachedStart = false;
        //        }
        //    }
        //    if (hasReachedStart == false && hasReachedEnd == true)
        //    {
        //        transform.position -= new Vector3(0f, 0f, 1f) * Time.deltaTime * moveSpeed;
        //        if (CurrentPlatform.transform.position.z >= 15)
        //        {
        //            hasReachedStart = true;
        //            hasReachedEnd = false;
        //        }
        //    }
        //}
    }


   

}
