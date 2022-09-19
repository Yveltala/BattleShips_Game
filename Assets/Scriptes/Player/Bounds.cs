using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
        if (tag == "Player") //Granice dla gracza (tylko on posiada tag 'player')
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.6f, 8.8f),
        Mathf.Clamp(transform.position.y, -4.6f, -0.55f), transform.position.z);
        else if(tag=="enemy") //Granice dla przeciwników 
        {
           transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 10f),
           Mathf.Clamp(transform.position.y, -6.6f, 4.6f), transform.position.z);
        }
    }
}
