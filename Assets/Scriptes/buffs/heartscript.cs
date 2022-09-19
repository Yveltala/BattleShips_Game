using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartscript : MonoBehaviour
{
    private float speed = 3f;
    public int health;
    private GameObject heartbuff;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
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
            health = GameObject.Find("Player").GetComponent<Health>().health_points;
            if (health != 6)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
