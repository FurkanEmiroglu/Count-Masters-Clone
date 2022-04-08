using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareNewEnemy : MonoBehaviour
{
    private ShootOut shootOutScript;
    [SerializeField] int _newEnemyAmount;
    [SerializeField] float _distance;

    private void Start() {
        shootOutScript = ObjectPooler.Instance.shootOutScript;
    }

    private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("Player")) {
            shootOutScript.setNewArea(_distance, _newEnemyAmount);
        }
    }
}
