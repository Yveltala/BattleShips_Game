using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public AudioSource soundcontrol; //d�wi�k strzelania
    private AudioClip[] sounds;
    public float attack_timer = 0.5f; //czas pomi�dzy strzelaniem
    public float currentat;
    public GameObject Player;
    private bool Attacking; //warto�� blokuj�ca atak bez odst�pu czasowego
    // Start is called before the first frame update
    void Start()
    {
        soundcontrol = Player.GetComponent<AudioSource>();
        sounds = Player.GetComponent<Health>().sounds;
}

    // Update is called once per frame
    void Update()
    {
        attack_timer += Time.deltaTime; 
        if (attack_timer > currentat)
        {
            Attacking = true; 
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Attacking)
            {
                Attacking = false;
                attack_timer = 0.8f;
                soundcontrol.clip = sounds[0];
                soundcontrol.Play();
            }
        }
    }
}
