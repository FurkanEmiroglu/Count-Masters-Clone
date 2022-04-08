using UnityEngine;
using TMPro;

public class DoorwayRewardTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshPro txt;
    [SerializeField] private RadialFormation _formation;
    [SerializeField] int _spawnCount;
    [SerializeField] bool _isMultiply;

    // Start is called before the first frame update
    void Start() { 
        if (!_isMultiply) txt.text = "+" + _spawnCount.ToString(); else txt.text = "x" + _spawnCount.ToString();
        _formation =  ObjectPooler.Instance.formation;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            AudioTree.Instance.playBubble();
            getRewarded();
            _formation.SetParametersWithDelay();
        }
    }

    void getRewarded() {
        if (!_isMultiply) _formation._amount += _spawnCount; else _formation._amount *= _spawnCount;
    }
}


