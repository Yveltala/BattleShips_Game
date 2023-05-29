using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    //Większość kodu w projekcie została napisana dosyć długi czas temu- od tamtego czasu zdobyłam zdecydowanie więcej doświadczenia, między innymi podczas praktyk
    public float PlayerSpeed = 5; 
    public Rigidbody2D Player; 
    public bool alive; 

    [SerializeField]
    private GameObject bullet; 

    [SerializeField]
    private Transform bullet_spawn; 
    
    public float attack_timer = 0.5f; 
    public float currentat;
    private bool Attacking; //
    [SerializeField]
    public int playerHealth; 
    // Start is called before the first frame update
    void Start()
    {
        alive = true; 

        Player = GetComponent<Rigidbody2D>(); 

        currentat = attack_timer; 
    }

    // Update is called once per frame
    void Update()
    {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");
        if (playerHealth <= 0) 
        {
            alive = false; 
        }
        if(alive==true) 
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
