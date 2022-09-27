using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundManager : MonoBehaviour {
    
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip clipLand, clipShatter, clipGem, clipFall, clipDead;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    public void LandSound() {
        soundFX.clip = clipLand;
        soundFX.Play();
    }

    public void ShatterSound() {
        soundFX.clip = clipShatter;
        soundFX.Play();
    }

    public void GemSound() {
        soundFX.clip = clipGem;
        soundFX.Play();
    }

    public void FallSound() {
        soundFX.clip = clipFall;
        soundFX.Play();
    }

    public void DeadSound() {
        soundFX.clip = clipDead;
        soundFX.Play();
    }
}
