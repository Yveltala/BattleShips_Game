using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Buff : MonoBehaviour
{
    private float speed = 3f;
    private GameObject shield;
    public GameObject player;
    public int buffnumber;
    public bool shieldactive = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    private void Awake()
    {
        buffnumber = Random.Range(0,2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        transform.position = temp;
        Destroy(gameObject, 2.7f);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")//jezeli pocisk dotknie gracza
        {
            gameObject.SetActive(false); 
        }

    }
}
