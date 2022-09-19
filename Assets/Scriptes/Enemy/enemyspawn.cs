using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyspawn : MonoBehaviour
{
    public GameObject[] enemieslist;
    float position;
    Vector3 temp;
    public float spawn_timer = 3;
    public float delay = 2f;
    public int typeofenemy;
    [SerializeField]
    public int max_enemies = 4;

    private List<GameObject> enemies = new List<GameObject>();
    private float time = 2f;
    // Start is called before the first frame update
    void Start()
    {
        time = delay;
    }
    // Update is called once per frame
    void Update()
    {
        typeofenemy = Random.Range(0, 3);
        var enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemies.Count >= max_enemies)
        {
            return;
        }

        time -= Time.deltaTime;
        time = Mathf.Max(time, 0f);
        if (time == 0f)
        {
            float position = Random.Range(-9.5f, 9.5f);
            temp = transform.position;
            temp.x = position;
            if(typeofenemy!=0)
            {
                GameObject obj = Instantiate(enemieslist[typeofenemy], temp, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
                enemies.Add(obj);
                spawn_timer = delay;
            }
            else
            {
                GameObject obj = Instantiate(enemieslist[typeofenemy], temp, Quaternion.Euler(0f, 0f, 180f)) as GameObject;
                enemies.Add(obj);
                spawn_timer = delay;
            }
        }
    }


    void LateUpdate()
    {
        enemies.RemoveAll(o => (o == null || o.Equals(null))); //niszczenie wszystkich obiekt�w
    }
}
