using UnityEngine;
using TMPro;

public class DoorwayRewardTrigger : MonoBehaviour
{
    public RadialFormation formation;
    public TextMeshProUGUI txt;
    [SerializeField] int _spawnCount;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "+" + _spawnCount.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            formation._amount += _spawnCount;
            formation.SetParameters();
        }
    }
}
