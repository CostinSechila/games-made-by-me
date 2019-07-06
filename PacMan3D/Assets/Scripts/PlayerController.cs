using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    public int score = 0;

    public int health = 3;

    public Transform portalLeft;
    public Transform portalRight;

    public Text healthScore;
    public Text scoreNumber;
    public Text gameOverText;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if ( characterController.isGrounded )
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if ( Input.GetButton("Jump") )
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }


    public void OnTriggerEnter(Collider collision)
    {
        if ( collision.gameObject.CompareTag("Point") )
        {
            Destroy(collision.gameObject);
            score++;
            if (score != 0)
            {

                scoreNumber.text = score.ToString();
            }
        }


      

        if (collision.gameObject.CompareTag("Ghost"))
        {
           
            health--;
            healthScore.text = health.ToString();
            if ( health <= 0 )
            {
                Destroy(gameObject);
                gameOverText.text = "Game Over";
                StartCoroutine(ResetGame());
            }

        }

        if (collision.gameObject.CompareTag("PortalLeft"))
        {
            gameObject.transform.position = portalRight.position - new Vector3(1.0f, 0.0f, 0.0f);
        }


        if (collision.gameObject.CompareTag("PortalRight"))
        {         
            gameObject.transform.position = portalLeft.position + new Vector3(1.0f, 0.0f, 0.0f);        
        }

    }


    IEnumerator ResetGame()
    {

       
        SceneManager.LoadScene(0);
        yield return new WaitForSecondsRealtime(2);
        

    }

   
}
