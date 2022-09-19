using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using UnityEditor;



public class highscore_d : MonoBehaviour
{
    [SerializeField]
    public Text scorelist;

    public string name;
    public string src;
    public char[] myArr;
    public string list;
    public string result = "";
    string inp_ln = "";
    public string[] lines;
    int i = 1;
    public string scorestext;
    public int noc = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (File.Exists("Dokumenty/HighScores.dat"))
        {
            string filename = System.IO.Path.Combine("Dokumenty/HighScores.dat");
            lines = System.IO.File.ReadAllLines(filename);
        }

        scorestext = inp_ln;

        foreach (string str in lines)
        {
            name = str.Take(3).ToString();
            src = str.Reverse().ToString();
            src = src.Substring(src.Length - 3);
        }

        for (int g = 0; g < 10; g++)
        {
            scorelist.text += g + 1 + "       " + name + "      " + src + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
