using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3shooting : MonoBehaviour
{
    public float speed = 1f; //predkosc pocisku (f=float)
    public bool alive;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "laser_bullet")
        {
            Destroy(gameObject, 0.9f); //pociski przeciwnikow znikaja po 3 sekundach
        }

        if (gameObject.tag == "charge")
        {
            Destroy(gameObject, 1.3f); //pociski przeciwnikow znikaja po 3 sekundach
        }
    }

    private void Update()
    {
        alive=GameObject.Find("enemy 3(Clone)").GetComponent<enemy3script>().alive;
        if(alive==false)
        {
            if (gameObject.tag == "laser_bullet")
            {
                Destroy(gameObject); //pociski przeciwnikow znikaja po 3 sekundach
            }

            if (gameObject.tag == "charge")
            {
                Destroy(gameObject); //pociski przeciwnikow znikaja po 3 sekundach
            }
        }
    }

}