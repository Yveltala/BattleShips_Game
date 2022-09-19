using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public float PlayerSpeed = 5; //predkosc gracza
    public Rigidbody2D Player; //komponent do poruszania sie
    public bool alive; //sprawdza czy gracz jest martwy czy nie-blokuje ruch i strzelanie po smierci

    [SerializeField]
    private GameObject bullet; //pole pobierajace pocisk

    [SerializeField]
    private Transform bullet_spawn; //pole w grze z ktorego wystrzeliwany jest pocisk
    
    public float attack_timer = 0.5f; //przerwa, jaka musi odczekac gracz pomiedzy strzalami
    public float currentat;
    private bool Attacking; //
    [SerializeField]
    public int playerHealth; //ilosc zdrowia gracza
    // Start is called before the first frame update
    void Start()
    {
        alive = true; //ustawiamy stan gracza jako 'zywy'

        Player = GetComponent<Rigidbody2D>(); //pobranie z gracza komponentu rigidbody

        currentat = attack_timer; 
    }

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");
        if (playerHealth <= 0) //jezeli zycie gracza spadnie ponizej 0, status zostanie zmieniony na 'martwy'
        {
            alive = false; //nwm czy to tak bylo, usun jak cos
        }
        if(alive==true) //tak dlugo jak gracz jest zywy, moze poruszac sie i strzelac
        {
        transform.position += new Vector3(moveX, 0, 0) * Time.deltaTime * PlayerSpeed;
        transform.position += new Vector3(0, moveY, 0) * Time.deltaTime * PlayerSpeed;
        Shoot();
        }
    }

    void Move(Vector3 direction)
    {
        if(alive==true)
        {
        Player.MovePosition((Vector3)transform.position+(direction*PlayerSpeed*Time.deltaTime));
        }
    }

    void Shoot()
    {
        attack_timer += Time.deltaTime;
        if(attack_timer>currentat)
        {
            Attacking = true;
        }
        if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (Attacking)
            {
                Attacking = false;
                attack_timer = 0.8f;
                Instantiate(bullet, bullet_spawn.position, Quaternion.identity);
            }
        }
    }


}
