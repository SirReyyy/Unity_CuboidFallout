using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private TextMesh currentScore;
    private int score;
    public static float timer;
    public static bool playerDead;

    void Awake() {
        currentScore = GameObject.Find("CurrentScore").GetComponent<TextMesh>();
        MakeInstance();
    }

    void Update() {
        currentScore.text = "  Score : "+ score; 
    }

    void MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    public void PlatformScore() {
        score += 100;
    }

    public void GemScore() {
        score += 500;
    }
}
