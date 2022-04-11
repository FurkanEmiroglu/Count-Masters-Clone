using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlashController : MonoBehaviour
{
    [SerializeField] private ParticleSystem muzzleFlash;

    public void MuzzleFlashEffect() {
        muzzleFlash.Play();
    }
}
