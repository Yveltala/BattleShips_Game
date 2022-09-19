using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class addscore : MonoBehaviour
{
    public string playername;
    [SerializeField]
    public Text name;
    [SerializeField]
    public Text score;
    public string pn;
    public float sc;
    public GameObject addsr;
    public GameObject scorerank;
    public GameObject badname;
    public GameObject shortname;
    public GameObject letters;

    public string[] cn;


    [Serializable]
    class SaveData
    {
        public float sc;
        public string pname;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pname()
    {
        pn = name.text.ToString();
        sc = float.Parse(score.text);
        pn=pn.ToUpper();
        if (
            pn == "FCK"
            || pn == "DCK"
            || pn == "ASS"
            || pn == "KKK"
            || pn == "LSD"
            || pn == "JEW"
            || pn == "COK"
            || pn == "DIK"
            || pn == "CNT"
            || pn == "SHT"
            || pn == "FUC"
            || pn == "FUK"
            || pn == "DIQ"
            || pn == "DIX"
            || pn == "FAG"
            || pn == "NIG"
            || pn == "NGR"
            || pn == "BCH"
            || pn == "CUM"
            || pn == "CLT"
            || pn == "KUM"
            || pn == "SUC"
            || pn == "SUK"
            || pn == "GAY"
            || pn == "LIC"
            || pn == "LIG"
            || pn == "GEI"
            || pn == "GAI"
            || pn == "FAP"
            || pn == "WTF"
            || pn == "PRN"
            || pn == "PUS"
            || pn == "TIT"
            || pn == "PIS"
            || pn == "KYS"
            || pn == "SXX"
            || pn == "POO"
            || pn == "ANL"
            || pn == "ORL"
            || pn == "MFF"
            || pn == "MLF"
            || pn == "SFU"
            || pn == "HUJ"
            || pn == "CYC"
            || pn == "SEX"
           )
        {
            badname.SetActive(true);
        }
        else if(pn.Length != 3)
        {
            shortname.SetActive(true);
        }

        else if(pn.Contains("`")
            || pn.Contains("~")
            || pn.Contains("!")
            || pn.Contains("@")
            || pn.Contains("#")
            || pn.Contains("$")
            || pn.Contains("%")
            || pn.Contains("^")
            || pn.Contains("&")
            || pn.Contains("*")
            || pn.Contains("(")
            || pn.Contains(")")
            || pn.Contains("-")
            || pn.Contains("_")
            || pn.Contains("+")
            || pn.Contains("=")
            || pn.Contains("[")
            || pn.Contains("{")
            || pn.Contains("}")
            || pn.Contains("]")
            || pn.Contains(";")
            || pn.Contains(":")
            || pn.Contains("'")
            || pn.Contains(" ")
            || pn.Contains(",")
            || pn.Contains("<")
            || pn.Contains(">")
            || pn.Contains(".")
            || pn.Contains("?")
            || pn.Contains("/")
            || pn.Contains("¹")
            || pn.Contains("æ")
            || pn.Contains("¿")
            || pn.Contains("œ")
            || pn.Contains("€")
            || pn.Contains("ó")
            || pn.Contains("ê")
            || pn.Contains("³")
            || pn.Contains("ñ")
            || pn.Contains("Ÿ")
            || pn.Contains("\""))
        {
            letters.SetActive(true);
        }
        else
        {
            AddScore();
        }
    }

    public void AddScore()
    {
            playername = pn;

            SaveData data = new SaveData();
            if (System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/HighScores.dat") ==false)
            {
                FileStream file = File.Create(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/HighScores.dat");
                file.Dispose();
                //StreamWriter sw = new StreamWriter(Application.persistentDataPath
                         //+ "/HighScores.dat", true);
                File.AppendAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)+ "/HighScores.dat",
                   playername + " " + sc + Environment.NewLine);
            }
            else
            {
                File.AppendAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/HighScores.dat",
                   playername + " " + sc + Environment.NewLine);
            }

        addsr.SetActive(false);
        scorerank.SetActive(true);

    }
}
