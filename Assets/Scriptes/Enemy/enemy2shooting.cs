using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2shooting : MonoBehaviour
{
    public float speed = 1f; //pr�dko�� pocisku (f=float)

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Enemy_bullet")
        {
            Destroy(gameObject, 2f); //pociski przeciwnik�w znikaj� po 3 sekundach
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fly(); //lot pocisku
    }
    void Fly()
    {
        Vector3 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "shield") //pobiera nazwe z obiektu collidera, w kt�ry uderzy�
        {
            gameObject.SetActive(false); //gdy pocisk dotknie gracza lub tarczy, zostaje wy��czony
        }
        else if (target.tag == "Player") //pobiera nazwe z obiektu collidera, w kt�ry uderzy�
        {
            gameObject.SetActive(false); //gdy pocisk dotknie gracza lub tarczy, zostaje wy��czony
        }
    }
}