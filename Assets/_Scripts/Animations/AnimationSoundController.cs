using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSoundController : MonoBehaviour
{
    [SerializeField] private AudioSource gunSound;
    [SerializeField] private MuzzleFlashController controller;

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

    void PlayMuzzleFlash() {
        controller.MuzzleFlashEffect();
    }
}
