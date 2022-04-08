using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTree : MonoBehaviour
{
    public static AudioTree Instance;
    public AudioSource spikeStabOnce;
    public AudioSource spikeStabMultiple;
    public AudioSource bubble;
    public AudioSource saw;
    public AudioSource metal;
    public AudioSource punchy;
    public AudioSource axe;
    public AudioSource walking;
    public AudioSource celebrate;
    private int _amount;

    private void Start() {
        GameEvents.current.onLevelComplete += playCelebrate;
        GameEvents.current.onGameOver += StopWalking;
        _amount = ObjectPooler.Instance.formation._amount;
    }
    


    // maybe we can use events and get rid of this singleton?
    #region Singleton
    private void Awake() {
        Instance = this;
    }
    #endregion

    public void playSpikeStabOnce() {
        spikeStabOnce.Play();
    }

    public void playBubble() {
        bubble.Play();
    }

    public void playSaw() {
        saw.Play();
    }

    public void playMetal() {
        metal.Play();
    }

    public void playPunchy() {
        punchy.Play();
    }

    public void playAxe() {
        axe.Play();
    }

    public void playWalking() {
        if (_amount != 0) {
        walking.Play();
        }
    }

    public void StopWalking() {
        walking.Stop();
    }

    public void playCelebrate() {
        if (_amount != 0) {
            celebrate.Play();
        }
    }

    public void PlayHitSound(GameObject obj) {
        var source = FindWhichHitSound(obj);
        if (!source.isPlaying) {
            source.Play();
        }
    }

    public AudioSource FindWhichHitSound(GameObject obj) {
        if (obj.CompareTag("spike")) {
            return spikeStabOnce;
        } else if (obj.CompareTag("saw")) {
            return saw;
        } else if (obj.CompareTag("metal")) {
            return metal;
        } else if (obj.CompareTag("punchy")) {
            return punchy;
        } else if (obj.CompareTag("axe")) {
            return axe;
        } return null;
    }
}
