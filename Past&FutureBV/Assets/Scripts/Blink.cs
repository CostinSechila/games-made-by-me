using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Vector2 mouseInput;

    

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V))
        {
            mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartCoroutine(miniTeleport(mouseInput));
        }
    }


    public IEnumerator miniTeleport (Vector2 mousePos)
    {
        transform.position = mousePos + new Vector2(0, 0.3f);

        yield return new WaitForSecondsRealtime(2);
    }
}
