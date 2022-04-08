using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeActivation : MonoBehaviour
{
    public static bool isRestarted = false;
    private void Start() {
        if (!isRestarted) {
            GameEvents.current.onStartGame += setDeactive;
        } else if (isRestarted) {
            setDeactive();
            GameEvents.current.StartGame();
        }
    }

    private void setActive() {
        gameObject.SetActive(true);
    }

    private void setDeactive() {
        gameObject.SetActive(false);
    }

    public void setRestarted() {
        isRestarted = true;
    }

    public void setNotRestarted() {
        isRestarted = false;
    }
}
