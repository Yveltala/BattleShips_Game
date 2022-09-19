using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private GameObject heartbuff; //obiekt/prefab serca
    public GameObject player; //gracz
    private GameObject playerbullet;

    public Image[] heart; //tablica zawierajaca grafiki kolejnych serc
    public int health_points; //liczba oznaczajaca ilosc punktow zycia
    public bool alive = true; //zmienna okreslajaca stan gracza (zywy lub nie)
    public float points; //liczba punktow (przechowywana w skrypcie 'Health') do ktorej odwolanie znajduje sie nastepnie w skrypcie 'GameOver'
    public GameObject Shield;

    public CameraShake shake_ur_ass; //skrypt odpowiadajacy za ruch kamery przy otrzymaniu obrazen
    public GameOver GameOverScreen; //ekran gameover

    public AudioSource soundcontrol; //dxwiek eksplozji
    public AudioClip[] sounds; //dzwiek obrazen (nie wykorzystywany)

    public Animator anim; //animacja
    public PolygonCollider2D player_Collider; //odwolanie do collidera gracza

    public bool shield = false;
    public bool freeze = false;

    void Start()
    {
        shake_ur_ass = GameObject.FindObjectOfType(typeof(CameraShake)) as CameraShake;
        player_Collider = GetComponent<PolygonCollider2D>(); //pobranie collidera od gracza
        player_Collider.enabled = true; //wlaczenie collidera gracza
    }
    // Update is called once per frame
    void Update()
    {
        points = GameObject.Find("Score").GetComponent<Pointspersec>().scoreAmount; //liczba punktow jest stale przekazywana tutaj, by mozna ja wyswietlic w ekranie GameOver
        for (int i=0;i<heart.Length;i++)  //petla dla wszystkich elementow w tablicy grafik
        {
            if(i< health_points)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }
        }
        if(shield==true)
        {
            Shield.SetActive(true);
        }
        else
        {
            Shield.SetActive(false);
        }
    }

    IEnumerator shieldbuff()
    {
        shield = true;
        soundcontrol.clip = sounds[4];
        soundcontrol.Play();
        yield return new WaitForSeconds(5);
        shield = false;
        soundcontrol.clip = sounds[5];
        soundcontrol.Play();
    }

    IEnumerator freezebuff()
    {
        freeze = true;
        soundcontrol.clip = sounds[6];
        soundcontrol.Play();
        yield return new WaitForSeconds(7);
        freeze = false;
        soundcontrol.clip = sounds[7];
        soundcontrol.Play();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy_bullet" && shield==false)//jezeli pocisk dotknie gracza
        {
            health_points = health_points - 1; //1 zycie mniej
            soundcontrol.clip = sounds[1];
            soundcontrol.Play(); //dzwiek obrazen
            shake_ur_ass.ShakeIt();
        }
        if (target.tag == "laser_bullet" && shield==false)//je�eli pocisk dotknie gracza
        {
            health_points = health_points - 2; //1 zycie mniej
            soundcontrol.clip = sounds[1];
            soundcontrol.Play(); //dzwiek obrazen
            shake_ur_ass.ShakeIt();
        }
        if ((target.tag == "laser_bullet" || target.tag=="Enemy_bullet") && shield == true)//je�eli pocisk dotknie gracza
        {
            soundcontrol.clip = sounds[8];
            soundcontrol.Play(); //dzwiek obrazen
        }
        if (health_points <= 0 && gameObject.tag == "Player") //jezeli gracz ma 0 lub mniej zycia
        {
            alive = false;
            points = (int)points;
            player_Collider.enabled = false;
            transform.gameObject.tag = "Explosion";
            soundcontrol.clip = sounds[2];
            soundcontrol.Play();//dzwiek eksplozji
            anim.Play("Explosion");//animacja eksplozji
            GameOverScreen.EndGame(points);
            Destroy(player, 0.7f); //gracz zostaje zniszczony dopiero po niecalej sekundzie, zeby dac czas animacji
        }
        if (target.tag == "heart" && health_points<6)//jezeli serce dotknie gracza
        {
            if(health_points==5)
            {
                health_points = health_points + 1; //1 zycie wiecej
            }
            else
            {
                health_points = health_points + 2; //2 zycie wiecej
            }
            soundcontrol.clip = sounds[3];
            soundcontrol.Play();
        }
        if (target.tag == "buff")
        {
            var buffnumber = target.GetComponent<Buff>().buffnumber;
            switch (buffnumber)
            {
                case 0:
                    StartCoroutine(shieldbuff());
                    break;
                case 1:
                    StartCoroutine(freezebuff());
                    break;
            }
        }
    }
}
