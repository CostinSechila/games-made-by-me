using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject platform;
    public float speed = 10f;

    public float yIncrement = 5f;

    public int score = 0;
    public int maxScore = 0;

    public GameObject center;

    public Rigidbody rb;

    public GameObject SpawnPosX;
    public GameObject EndPosX;

    public GameObject SpawnPosZ;
    public GameObject EndPosZ;

    public Text scoreText;
    public Text maxScoreText;
    public Text gameOver;

    public string gameOverString = "GameOver";

    public Camera cam;

    public void Start()
    {
        maxScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        Instantiate(platform, SpawnPosX.transform.position + new Vector3(0f, yIncrement, 0f), Quaternion.identity);
    }


    public void Update()
    {
       
        if (Input.GetMouseButtonDown(1) )
        {
            MovingPlatform.CurrentPlatform.Stop();
            MovingPlatform.CurrentPlatform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
          
            
            
        }
        if (MovingPlatform.CurrentPlatform.hasFallen == true || MovingPlatform.CurrentPlatform.isGrounded == true)
        {
           
           
            if (MovingPlatform.CurrentPlatform.isGrounded == true)
            {
                score++;
                scoreText.text = score.ToString();
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                    maxScoreText.text = score.ToString();
                }
                maxScoreText.text = maxScore.ToString();
                SpawnPlatform();
                cam.transform.position += new Vector3(0f, 0.7f, 0f);
            }
            else if (MovingPlatform.CurrentPlatform.hasFallen == true)
            {
                Debug.Log("hasFallen true");
                gameOver.text = gameOverString;

                SceneManager.LoadScene(1);
                Debug.Log(gameOverString);
            }
        }

    }

    public void SpawnPlatform()
    {
        GeneratePlatform();
        if (MovingPlatform.CurrentPlatform.isGrounded == true)
        {
            if (MovingPlatform.CurrentPlatform.direction == 1)
            { 
                Instantiate(platform, SpawnPosX.transform.position + new Vector3(0f, yIncrement, 0f), Quaternion.identity);
                yIncrement += 1.3f;
                //MovingPlatform.CurrentPlatform.direction = 2;
            }
            //if (MovingPlatform.CurrentPlatform.direction == 2)
            //{
            //    Instantiate(platform, SpawnPosZ.transform.position + new Vector3(0f, yIncrement, 0f), Quaternion.identity);
            //    yIncrement += 1.5f;
            //    MovingPlatform.CurrentPlatform.direction = 1;
            //}
        }
    }

    public void GeneratePlatform()
    {
        float x = Random.Range(5, 9);
        float z = Random.Range(5, 9);

        Vector3 scaleVector = new Vector3(x, 1, z);
        rb.mass = (x + z) / 2;

        platform.transform.localScale = scaleVector;

       
    }







}
