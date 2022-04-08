using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteActivation : MonoBehaviour
{
    private void Start() {
        setDeactive();
        GameEvents.current.onLevelComplete += setActive;
    }

    private void setActive() {
        gameObject.SetActive(true);
    }

    private void setDeactive() {
        gameObject.SetActive(false);
    }
}
