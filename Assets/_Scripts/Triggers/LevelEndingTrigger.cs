using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndingTrigger : MonoBehaviour
{
    ShootOut shootOutScript;
    private void Start() {
        shootOutScript = ObjectPooler.Instance.shootOutScript;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            shootOutScript.setIsLastTrue();
        }
    }
}
