using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_soundcontrol : MonoBehaviour
{
    public AudioSource explosion;
    public AudioSource bullet;
    // Start is called before the first frame update
    void Start()
    {
        explosion = gameObject.AddComponent<AudioSource>();
        bullet = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
