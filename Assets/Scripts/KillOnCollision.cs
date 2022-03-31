using UnityEngine;

public class KillOnCollision : MonoBehaviour
{

    public RadialFormation formationScript;
    private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CloneCharacter"))
        {
            formationScript._amount--;
            if (formationScript._amount > 0)
            {
                formationScript.SetParameters();
            }
            else
            {
                gameManager.gameOver();
            }
        }
    }

}
