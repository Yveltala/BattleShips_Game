using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioClip[] menu_music;
    public AudioSource menu_control;
    private AudioSource soundcontrol;
    public GameObject highscores;
    void Start()
    {
        soundcontrol = FindObjectOfType<AudioSource>();
        soundcontrol.loop = false;
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("battle ships");
        soundcontrol.clip = sounds[0];
        soundcontrol.Play();
    }

    public void OptionsButton()
    {

    }

    public void HighscoresButton()
    {
        highscores.SetActive(true);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
