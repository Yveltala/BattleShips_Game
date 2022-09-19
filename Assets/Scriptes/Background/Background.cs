using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float speed = 0.1f; //szybkoœæ przewijania
    private MeshRenderer tex;
    private float sc;
    // Start is called before the first frame update
    void Awake()
    {
        tex = GetComponent<MeshRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Animation();
    }
    void Animation()
    {
        sc = Time.time * speed;
        Vector3 offset = new Vector3(0f,sc);
        tex.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
