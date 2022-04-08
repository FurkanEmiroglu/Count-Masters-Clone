using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem confetti1;
    [SerializeField] private ParticleSystem confetti2;
    [SerializeField] private ParticleSystem confetti3;
    [SerializeField] private ParticleSystem confetti4;

    private void Start() {
        GameEvents.current.onLevelComplete += PlayConfettiParticles;
    }

    private void PlayConfettiParticles() {
        confetti1.Play();
        confetti2.Play();
        confetti3.Play();
        confetti4.Play();
    }
}
