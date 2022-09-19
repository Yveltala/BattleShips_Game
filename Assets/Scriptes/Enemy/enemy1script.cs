using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;
public class enemy1script : MonoBehaviour
{
    
    [SerializeField]
    private GameObject bullet;
    public AudioClip[] sounds;
    private AudioSource soundcontrol;
    [SerializeField]
    private Transform bullet_spawn;
    [SerializeField]
    public GameObject heart;
    [SerializeField]
    public GameObject buff;
    [SerializeField]
    private Transform heart_spawn;

    public float attack_timer = 2f;
    public float currentat;
    private bool Attacking;
    public float speed = 5f;
    public bool shooting;
    public bool moving = false;
    public bool MoveLeft;
    public GameObject ice;
    public int i = 2;

    public int enemy_health = 3;
    public GameObject bulletEnemy;
    public GameObject enemy;
    public Animator anim;
    public Rigidbody2D enemy_rb;
    float number;
    public bool alive=true;
    public int heartrandom;
    public int buffrandom;
    public bool frozen_status;
    public GameObject particles;
    public GameObject beam;
    public float attack;

    public float score;

    // Start is called before the first frame update
    void Awake()
    {
        
        soundcontrol = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        number = Random.Range(1.0f, 4.3f);
        buffrandom = Random.Range(0, 100);
        heartrandom = Random.Range(0, 100);

        score = GameObject.Find("Score").GetComponent<Pointspersec>().scoreAmount;
        int score_limit = 500;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = i;
        enemy_rb = GetComponent<Rigidbody2D>();

        if (score > 1000)
        {
            speed = 3.7f;
            attack_timer = 1.70f;
            attack = attack_timer;
        }
        if (score > 3000)
        {
            speed = 4f;
            attack_timer = 1.50f;
            attack = attack_timer;
        }
        if (score > 5000)
        {
            speed = 4.5f;
            attack_timer = 1.00f;
            attack = attack_timer;
        }
        if (score > 7000)
        {
            speed = 4.7f;
            attack_timer = 0.90f;
            attack = attack_timer;
        }
        if (score > 10000)
        {
            speed = 5f;
            attack_timer = 0.80f;
            attack = attack_timer;
        }
    }
    void Start()
    {
        
        InvokeRepeating("Shoot", 2, (float)attack_timer);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = gameObject.transform.position;
        moving = false;
        position.y = number;
        if(transform.position != position)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
        }
        if(transform.position== position && frozen_status == false)
        {
            moving = true;
        }
        if (moving == true && alive== true && frozen_status == false)
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
        if (enemy_health <= 0 && gameObject.tag=="Enemy")
        {
            alive = false;
            transform.gameObject.tag = "Explosion";
            soundcontrol.clip = sounds[0];
            soundcontrol.Play();
            Destroy(particles);
            Destroy(beam);
            anim.Play("explosion");
            Destroy(enemy, 0.6f);
            if(heartrandom>95)
            {
                Instantiate(heart, heart_spawn.position, Quaternion.identity);
            }
            if (buffrandom > 90)
            {
                Instantiate(buff, heart_spawn.position, Quaternion.identity);
            }
            GameObject.Find("Score").GetComponent<Pointspersec>().scoreAmount += 100f;
        }
        if (target.tag == "Freeze_bullet")
        {
            StartCoroutine(frozen());
        }
    }

    IEnumerator frozen()
    {
        moving = false;
        frozen_status = true;
        if (enemy_health>1) ice.SetActive(true);
        yield return new WaitForSeconds(3);
        moving = true;
        frozen_status = false;
        ice.SetActive(false);
        soundcontrol.clip = sounds[2];
        soundcontrol.Play();
    }

    void Shoot()
    {
        if(alive==true && frozen_status == false)
        {

        attack_timer += Time.deltaTime;
        if (attack_timer > currentat)
        {
            Attacking = true;
        }
            if (Attacking)
            {
                Attacking = false;
                attack_timer = attack;
                Instantiate(bullet, bullet_spawn.position, Quaternion.identity);
                soundcontrol.clip = sounds[1];
                soundcontrol.Play();
            }
    }

    }
}
