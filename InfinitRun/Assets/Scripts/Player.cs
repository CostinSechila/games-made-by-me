using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector3 targetPos;
    public float Yincrement;

    public float speed;

    public float maxHeight;
    public float minHeight;

    public float health;

    public GameObject effect;
    public Text healthDisplay;
    public Text startText;

    public void Start()
    {
        StartCoroutine(ShowText());
    }

    void Update()
    {
        healthDisplay.text = health.ToString();

        if (health <= 0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }



        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector3(transform.position.x, transform.position.y + Yincrement, 0f);
            
        }
        else if ( Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            targetPos = new Vector3(transform.position.x, transform.position.y - Yincrement, 0f);
           
        }
    }


    IEnumerator ShowText()
    {
       
        yield return new WaitForSecondsRealtime(4);

        startText.text = "";

        yield return null;
    }
}
