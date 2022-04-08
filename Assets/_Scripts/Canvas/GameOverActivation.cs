using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverActivation : MonoBehaviour
{
    private void Start() {
        setDeactive();
        GameEvents.current.onGameOver += setActive;
    }

    private void setActive() {
        gameObject.SetActive(true);
    }

    private void setDeactive() {
        gameObject.SetActive(false);
    }
}
