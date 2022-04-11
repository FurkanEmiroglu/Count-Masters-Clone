using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class WelcomeActivation : MonoBehaviour
{
    public static bool isRestarted = false;
    private GameObject obj;
    public List<GameObject> reverseobj = new List<GameObject>();
    

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
