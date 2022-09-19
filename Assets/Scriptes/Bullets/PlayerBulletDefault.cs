using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletDefault : MonoBehaviour
{
    public float speed = 3f; //prêdkoœæ pocisku (literka f oznacza float)
    public bool freezeb = false;
    public GameObject player;
    public SpriteRenderer newsprite;
    public Sprite frozenbullet;
    public Sprite normalbullet;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "bullet(Clone)")
        {
            Destroy(gameObject, 1.1f);
        }  
    }

    // Update is called once per frame
    void Update()
    {
        freezeb = GameObject.Find("Player").GetComponent<Health>().freeze;
        if (freezeb == true)
        {
            newsprite.sprite = frozenbullet;
            gameObject.tag = "Freeze_bullet";

        }
        else
        {
            gameObject.tag = "Player_bullet";
            newsprite.sprite = normalbullet;
        }
        Fly(); 
    }

    void Fly()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag=="Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
