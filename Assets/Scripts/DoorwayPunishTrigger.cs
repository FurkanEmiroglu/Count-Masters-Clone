using UnityEngine;
using TMPro;

public class DoorwayPunishTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt;
    public RadialFormation formation;
    public GameManager gameManager;
    [SerializeField] int killCount;

    void Start()
    {
        txt.text = "-" +  killCount.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            formation._amount -= killCount;
            if (formation._amount > 0)
            {
                formation.SetParameters();
            }
            else
            {
                gameManager.gameOver();
            }
        }
    }
}
