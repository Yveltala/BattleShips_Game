using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class Pointspersec : MonoBehaviour
{
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasedPerSecond;

    public int health;

    bool CheckIfAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckIfAlive==true) {
            health = GameObject.Find("Player").GetComponent<Health>().health_points;

            if (health <= 0) {
                CheckIfAlive = false;
            }
            
            scoreText.text = "Wynik: " + (int)scoreAmount;
            scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
        }
        else if (CheckIfAlive==false) {
            scoreText.text = "Wynik: " + (int)scoreAmount;
        }
    }

}
