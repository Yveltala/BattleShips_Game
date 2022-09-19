using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text : MonoBehaviour
{
    public GameObject strzelanie;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowMessage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowMessage()
    {
        strzelanie.SetActive(true);
        yield return new WaitForSeconds(3);
        strzelanie.SetActive(false);
    }
}
