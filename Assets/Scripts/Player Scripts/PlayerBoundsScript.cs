using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundsScript : MonoBehaviour {

    private Animator anim;

    private float minBoundX = -2.6f, maxBoundX = 2.6f, minBoundY = -5.5f;
    private bool isOutOfBounds;

    void Update() {
        CheckBounds();
    }

    void CheckBounds() {
        Vector2 temp = transform.position;

        if(temp.x > maxBoundX)
            temp.x = maxBoundX;
        if(temp.x < minBoundX)
            temp.x = minBoundX;

        transform.position = temp;

        if(temp.y <= minBoundY) {
            if(!isOutOfBounds) {
                isOutOfBounds = true;

                gameObject.SetActive(false);
                SoundManager.instance.FallSound();
                ScoreManager.playerDead = true;
                GameOverManager.instance.GameOverShowPanel();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Gem") {
            target.gameObject.SetActive(false);
            SoundManager.instance.GemSound();
            ScoreManager.instance.GemScore();
        }
        if(target.tag == "Spikes") {
            gameObject.SetActive(false);
            SoundManager.instance.DeadSound();
            ScoreManager.playerDead = true;
            GameOverManager.instance.GameOverShowPanel();
        }
    }
}
