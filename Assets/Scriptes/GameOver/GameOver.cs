using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text text_score;

    public void EndGame(float score) {
        gameObject.SetActive(true);
        text_score.text = score.ToString();
        Time.timeScale = 0;
    }
    public void RestartButton() {
        Time.timeScale = 1;
        SceneManager.LoadScene("battle ships");
    }
    public void MainMenuButton(){
        Time.timeScale = 1;
        SceneManager.LoadScene("main menu");
    }
}
