using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class nameregex : MonoBehaviour
{
    public string name;
    public Text n;
    public Text newtext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGUI()
    {
        newtext.text = Regex.Replace(n.text, @"[^a-zA-Z0-9 ]","");

    }
}
