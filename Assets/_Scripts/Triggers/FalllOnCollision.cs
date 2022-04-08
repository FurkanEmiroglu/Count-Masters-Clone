using UnityEngine;

public class FallOnCollision : MonoBehaviour
{
    [SerializeField] private RadialFormation _formation;

    private void Start() {
        _formation = ObjectPooler.Instance.formation;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("CloneCharacter")) {
            other.transform.parent = null;
            other.transform.position = Vector3.Lerp(transform.position, this.gameObject.transform.position, 0.125f);
        }
    }
}
