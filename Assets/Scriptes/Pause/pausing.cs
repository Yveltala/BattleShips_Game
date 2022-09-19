using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausing : MonoBehaviour
{
    public GameObject pausescreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausescreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
