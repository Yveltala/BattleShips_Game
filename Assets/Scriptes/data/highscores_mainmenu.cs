using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class highscores_mainmenu : MonoBehaviour
{
    
    public string name;
    public string src;
    public char[] myArr;
    public string list;
    public string result = "";
    string inp_ln = "";
    public GameObject higscore;

    public int compare;

    List<string> scores = new List<string>();

    public string[] lines;
    int i = 1;
    public string scorestext;
    public int noc = 0;
    void Start()
    {
        Text scorelist = GameObject.Find("Scorelist").GetComponent<Text>();

        Text number = GameObject.Find("number").GetComponent<Text>();
        Text nametext = GameObject.Find("name").GetComponent<Text>();
        Text scoretext = GameObject.Find("score").GetComponent<Text>();

        if (System.IO.File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/HighScores.dat"))
        {
            StreamReader sw = new StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/HighScores.dat", true);
            lines = System.IO.File.ReadAllLines(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/HighScores.dat");
        }

        string[] john=new string[lines.Length];
        string[] yone=new string[lines.Length];

        /*for (int i=1;i<lines.Length;i++)
        {
            compare=string.Compare(lines[i-1].Remove(0, 4), lines[i].Remove(0, 4));
            if(compare==1)
            {
                john[i-1] = lines[i-1].ToString().Remove(0, 4);
                john[i] = lines[i].ToString().Remove(0, 4);

                yone[i - 1] = lines[i - 1].ToString().Substring(0, 3);
                yone[i] = lines[i].ToString().Substring(0, 3);
            }

            else if(compare==-1)
            {
                john[i - 1] = lines[i - 1].ToString().Remove(0, 4);
                john[i] = lines[i].ToString().Remove(0, 4);

                yone[i - 1] = lines[i - 1].ToString().Substring(0, 3);
                yone[i] = lines[i].ToString().Substring(0, 3);
            }

            else
            {
                john[i - 1] = lines[i - 1].ToString().Remove(0, 4);
                john[i] = lines[i].ToString().Remove(0, 4);

                yone[i - 1] = lines[i - 1].ToString().Substring(0, 3);
                yone[i] = lines[i].ToString().Substring(0, 3);
            }
        }*/

        string temp = "";
        string temps = "";
        /*for (int i = 0; i <= lines.Length - 1; i++)
        {
            for (int j = i + 1; j < lines.Length; j++)
            {
                if (int.Parse(lines[i].Remove(0, 4)) > int.Parse(lines[j].Remove(0, 4)))
                {
                    temp = lines[i].ToString().Remove(0, 4);
                    temps = lines[i].ToString().Substring(0, 3);

                    john[j] = lines[i].ToString().Remove(0, 4);
                    john[i] = temp;

                    yone[j] = lines[i].ToString().Substring(0, 3);
                    yone[i] = temps;
                }

                else 
                {
                    temp = lines[j].ToString().Remove(0, 4);
                    john[j] = lines[j].ToString().Remove(0, 4);
                    john[i] = temp;

                    yone[j] = lines[j].ToString().Substring(0, 3);
                    yone[i] = lines[i].ToString().Substring(0, 3);
                }
            }
        }*/


        for (int i = 0; i < lines.Length - 1; i++)
        {
            for (int j = i + 1; j < lines.Length; j++)
            {
                if (int.Parse(lines[i].Remove(0, 4)) < int.Parse(lines[j].Remove(0, 4)))
                {
                    temp = lines[i];
                    lines[i] = lines[j];
                    lines[j] = temp;
                }
            }
        }

        /*for (int g = 0; g < 10; g++)
        {
            john[g+1]=
            yone[g + 1] =
        }



            for (int g = 0; g < 10; g++)
            {
                scorelist.text += g + 1 + "       " + name + "      " + src + "\n";
            }

            for (int g = 0; g < 10; g++)
            {
                name = lines[g].ToString().Substring(0, 3);
                src = lines[g].ToString().Remove(0, 4);
                scorelist.text += g + 1 + "       " + lines[g].ToString().Substring(0, 3) + "      " + lines[g].ToString().Remove(0,4) + "\n";
            }*/

            for (int g = 0; g < 10; g++)
        {
            name = lines[g].ToString().Remove(0, 4);
            src = lines[g].ToString().Substring(0, 3);
            number.text += g + 1 + "\n";
            nametext.text += name + "\n";
            scoretext.text += src + "\n";
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            higscore.SetActive(false);
        }
    }
}

    



