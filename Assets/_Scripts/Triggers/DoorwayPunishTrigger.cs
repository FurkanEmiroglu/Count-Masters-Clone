using UnityEngine;
using TMPro;

public class DoorwayPunishTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshPro txt;
    [SerializeField] RadialFormation _formation;
    [SerializeField] int _killCount;
    [SerializeField] bool _isDivision;

    void Start()
    {
        if (!_isDivision) txt.text = "-" + _killCount.ToString(); else txt.text = "÷" + _killCount.ToString();
        _formation = ObjectPooler.Instance.formation;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioTree.Instance.playBubble();
            getPunished();
            _formation.SetParametersWithDelay();
        }
    }

    void getPunished()
    {
        if (!_isDivision) _formation._amount -= _killCount; else _formation._amount /= _killCount;
    }
}
