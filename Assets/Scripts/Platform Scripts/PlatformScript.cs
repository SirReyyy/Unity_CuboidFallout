using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {
    public float moveSpeed = 2.0f;
    public float boundY = 6.0f;

    public bool isSpeedPlatformLeft, isSpeedPlatformRight, isGlass, isSpike, isPlatform;

    private Animator anim;


    void Awake() {
        if(isGlass)
            anim = GetComponent<Animator>();
    }

    void Update() {
        Move();
    }

    void Move() {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        if(temp.y >= boundY) {
            gameObject.SetActive(false);
        }
    }

    void GlassDeactivate() {
        Invoke("DeactivateGlassPlatform", 1.0f);
    }

    void DeactivateGlassPlatform() {
        SoundManager.instance.ShatterSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target) {    
        if(target.tag == "Player") {
            if(isSpike) {
                target.gameObject.SetActive(false);
                SoundManager.instance.DeadSound();
                ScoreManager.playerDead = true;
                GameOverManager.instance.GameOverShowPanel();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.tag == "Player") {
            if(isGlass) {
                SoundManager.instance.LandSound();
                anim.Play("Glass Break Animation");
            }
            if(isPlatform) {
                SoundManager.instance.LandSound();
                ScoreManager.instance.PlatformScore();
            }
        }
    }

    void OnCollisionStay2D(Collision2D target) {
        if(target.gameObject.tag == "Player") {
            if(isSpeedPlatformLeft) {
                SoundManager.instance.LandSound();
                target.gameObject.GetComponent<PlayerMovementScript>().PlatformMove(-1.0f);
            }
            if(isSpeedPlatformRight) {
                SoundManager.instance.LandSound();
                target.gameObject.GetComponent<PlayerMovementScript>().PlatformMove(1.0f);
            }
        }
    }
}
