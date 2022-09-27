using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject Start;

    void Awake() {
        MakeInstance();
        CreateInitialPlatform();
    }

    void MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    void CreateInitialPlatform() {
        Vector3 temp = new Vector3(0.0f, -4.0f, 0);
        Instantiate(Start, temp, Quaternion.identity);

        temp.y += 4.0f;
        Instantiate(Player, temp, Quaternion.identity);
    }

    public void RestartGame() {
        Invoke("RestartAfterTime", 3.0f);
    }

    void RestartAfterTime() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGameplay");
    }
}
