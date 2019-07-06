using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    //private SpeedBoostItem speedBoost;
    private float moveBoost = 3;
    private float slowAmount = 0.15f;

    public int up = 1, down = 2, left = 3, right = 4;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //private void Update()
    //{
        
    

    //    Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

       
    //    rb.MovePosition(rb.position + moveVelocity);
    //}


    private void FixedUpdate()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * movSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveVelocity);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //speedBoost = GameObject.FindGameObjectWithTag("SpeedBoost").GetComponent<SpeedBoostItem>();
        if ( collision.CompareTag("SpeedBoost") )
        {
            

            StartCoroutine (BoostSpeed(moveBoost));
        }
        if ( collision.CompareTag("BearTrap") )
        {
            StartCoroutine(SlowSpeed(slowAmount));
        }
        if ( collision.CompareTag("SlowArea") )
        {
            movSpeed = movSpeed - 0.5f;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.CompareTag("SlowArea") )
        {
            movSpeed = movSpeed + 0.5f;
        }
    }



    public IEnumerator BoostSpeed( float amount )
    {
        Debug.Log(movSpeed);

        movSpeed += amount;

        Debug.Log(movSpeed);


        yield return new WaitForSecondsRealtime(3);

        Debug.Log(movSpeed);
        movSpeed -= amount;

        Debug.Log(movSpeed);

   
    }

    public IEnumerator SlowSpeed ( float amount )
    {
        movSpeed -= amount;

        yield return new WaitForSecondsRealtime(4);

        movSpeed += amount;
    }

    



}
