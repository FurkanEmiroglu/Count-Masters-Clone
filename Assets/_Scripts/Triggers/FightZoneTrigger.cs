using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            GameEvents.current.FightZoneTriggerEnter();
        }
    }
}
