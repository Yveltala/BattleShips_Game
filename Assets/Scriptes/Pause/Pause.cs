using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void QuitButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("main menu");
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
