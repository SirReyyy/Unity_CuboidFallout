using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    private GameObject gameOverPanel;

    private Text gameOverText;
    private Button restartBtn, homeBtn;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
        InitializeVariables();
    }

    public void GameOverShowPanel() {
        gameOverPanel.SetActive(true);
    }

    void InitializeVariables() {
        gameOverPanel = GameObject.Find("GameOver Panel Holder");

        restartBtn = GameObject.Find("RestartBtn").GetComponent<Button>();
        homeBtn = GameObject.Find("HomeBtn").GetComponent<Button>();

        restartBtn.onClick.AddListener(() => Restart());
        homeBtn.onClick.AddListener(() => Home());

        gameOverPanel.SetActive(false);
    }

    void Restart() {
        SceneManager.LoadScene("Gameplay");
    }

    void Home() {
        SceneManager.LoadScene("MainMenu");
    }

}
