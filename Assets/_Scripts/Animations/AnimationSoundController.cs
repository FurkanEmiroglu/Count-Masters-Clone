using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource gunSound;

    private void Start() {
        gunSound = GameObject.Find("AudioTree/uspSound").GetComponent<AudioSource>();
    }


    // these functions are used as animation events
    void playGunSound() {
        gunSound.Play();
    }

    void stopGunSound() {
        gunSound.Stop();
    }
}
