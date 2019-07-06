using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoScorer : MonoBehaviour
{
    private Text ammoText;
    private Attack playerAttack;


    void Start()
    {
        ammoText = GetComponent<Text>();
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = playerAttack.ammo.ToString();
    }
}
