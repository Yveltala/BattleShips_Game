using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;
public class enemy3script : MonoBehaviour
{
    private Rigidbody2D enemy_rb;
    [SerializeField]
    private GameObject bullet;
    public GameObject chargeobj;
    public AudioClip[] sounds;
    private AudioSource soundcontrol;
    [SerializeField]
    private Transform bullet_spawn;
    [SerializeField]
    private Transform charge_spawn;
    [SerializeField]
    public GameObject heart;
    [SerializeField]
    private Transform heart_spawn;
    [SerializeField]
    public GameObject buff;
    public GameObject particles;

    public float attack_timer = 6f;
    public float currentat = 0f;
    private bool Attacking;
    public float speed = 6f;
    public bool shooting;
    private bool moving;
    public bool MoveLeft;

    public int enemy_health = 3;
    public GameObject bulletEnemy;
    public GameObject enemy;
    public Animator anim;
    float number;
    public int heartrandom;
    public int buffrandom;
    public GameObject ice;
    public int i = 0;

    public GameObject charge_copy;

    public bool alive = true;
    public float score;
    public bool charge = false;
    public bool frozen_status = false;

    public float attack;

    // Start is called before the first frame update
    void Awake()
    {
        soundcontrol = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        number = Random.Range(1.0f, 4.3f);
        buffrandom = Random.Range(0, 100);
        heartrandom = Random.Range(0, 100);

        float score_limit = 1000;
        score = GameObject.Find("Score").GetComponent<Pointspersec>().scoreAmount;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = i;
        enemy_rb = GetComponent<Rigidbody2D>();
        if (score > 1000)
        {
            speed = 3.5f;
            attack_timer = 5.30f;
            attack = attack_timer;
        }
        if (score > 3000)
        {
            speed = 3.7f;
            attack_timer = 5.00f;
            attack = attack_timer;
        }
        if (score > 5000)
        {
            speed = 4f;
            attack_timer = 4.50f;
            attack = attack_timer;
        }
        if (score > 7000)
        {
            speed = 4.2f;
            attack_timer = 4.30f;
            attack = attack_timer;
        }
        if (score > 10000)
        {
            speed = 4.5f;
            attack_timer = 4.10f;
            attack = attack_timer;
        }
    }
    void Start()
    {
        
        if (enemy_health!=0) InvokeRepeating("chargeanimation", 6, (float)attack_timer);

        
    }

    // Update is called once per frame
    void Update()
    {
        
        var position = gameObject.transform.position;
        position.y = number;
        moving = false;
        if (transform.position != position )
        {
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
        }
        if (transform.position == position && frozen_status == false)
        {
            moving = true;
        }
        if (moving == true && alive==true && charge==false && frozen_status==false)
        {
            if (MoveLeft == true)
            {
                Vector3 temp = transform.position;
                temp.x -= speed * Time.deltaTime;
                transform.position = temp;
                if (transform.position.x <= -8.76) MoveLeft = false;
            }
            else
            {
                Vector3 temp = transform.position;
                temp.x += speed * Time.deltaTime;
                transform.position = temp;
                if (transform.position.x >= 8.8) MoveLeft = true;
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player_bullet" || target.tag == "Freeze_bullet")
            enemy_health = enemy_health - 1;
        if (enemy_health <= 0 && gameObject.tag == "Enemy")
        {
            frozen_status = false;
            alive = false;
            transform.gameObject.tag = "Explosion";
            soundcontrol.clip = sounds[0];
            soundcontrol.Play();
            Destroy(particles);
            Destroy(charge_copy);
            anim.Play("explosion");
            Destroy(enemy, 0.6f);
            if (heartrandom > 95)
            {
                Instantiate(heart, heart_spawn.position, Quaternion.identity);
            }
            if (buffrandom > 90)
            {
                Instantiate(buff, heart_spawn.position, Quaternion.identity);
            }
            GameObject.Find("Score").GetComponent<Pointspersec>().scoreAmount += 100f;
        }

        if(target.tag=="Freeze_bullet")
        {
            StartCoroutine(frozen());
        }
    }

    IEnumerator frozen()
    {
        moving = false;
        frozen_status = true;
        if (enemy_health > 1) ice.SetActive(true);
        yield return new WaitForSeconds(3);
        moving = true;
        frozen_status = false;
        ice.SetActive(false);
        soundcontrol.clip = sounds[4];
        soundcontrol.Play();
    }


    void Shoot()
    {
        if (alive == true && frozen_status==false)
        {
            attack_timer += Time.deltaTime;
            if (attack_timer > currentat)
            {
                Attacking = true;
            }
            if (Attacking==true)
            {
                Attacking = false;
                attack_timer = attack;
                Instantiate(bullet, bullet_spawn.position, Quaternion.identity);
                soundcontrol.clip = sounds[3];
                soundcontrol.Play();
            }
        }
    }

    void Charge()
    {
        if(frozen_status==false)
        {
            charge_copy=(GameObject) Instantiate(chargeobj, charge_spawn.position, Quaternion.identity);
            soundcontrol.clip = sounds[2];
            soundcontrol.Play();
        }  
    }

    void Move()
    {
        charge = false;
    }

    void chargeanimation()
    {
        if (alive == true && frozen_status==false)
        {
            charge = true;
            anim.Play("charge");
        }
    }
}
