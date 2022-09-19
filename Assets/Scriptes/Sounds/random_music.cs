using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_music : MonoBehaviour
{
    public AudioClip[] music;
    private AudioSource audios;
    private bool alive;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
        audios.loop = false;
    }
    private AudioClip GetRandomClip()
    {
        return music[Random.Range(0,music.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            alive = Player.GetComponent<Health>().alive;
        }
        if (!audios.isPlaying)
        {
            audios.clip=GetRandomClip();
            audios.Play();
        }
        if(alive==false || Player==null)
        {
            audios.Stop();
        }
    }
}
