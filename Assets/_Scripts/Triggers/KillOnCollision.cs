using UnityEngine;
using System.Collections;

public class KillOnCollision : MonoBehaviour
{
    [SerializeField] private RadialFormation _formation;
    [SerializeField] private FriendlyArmy _friendlyArmy;
    [SerializeField] private AudioSource hitSound;
    bool isHit;

    private void Start() {
        hitSound = AudioTree.Instance.FindWhichHitSound(this.gameObject);
        _formation = ObjectPooler.Instance.formation;
        _friendlyArmy = ObjectPooler.Instance.friendlyArmy;
    }

    private void OnTriggerEnter(Collider other) {
        _formation._amount--;
        _formation.SetParametersWithDelay();
        AudioTree.Instance.PlayHitSound(gameObject);



        /*if (other.gameObject.CompareTag("CloneCharacter")) {
            hitSound.Play();
            _formation._amount--;
            _formation.SetParametersWithDelay();
            //playHitSound();
        }*/
    }
}
