using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    Animator animator;
    Transform _targetToShoot;

    // this controller is for enemy units
    private void Start() {
        animator = GetComponentInChildren<Animator>();
        _targetToShoot = ObjectPooler.Instance.MainCharacter.transform;
        stopFight();
        GameEvents.current.OnFightZoneTriggerEnter += startFight;
        GameEvents.current.OnFightZoneTriggerExit += stopFight;
    }

    private void OnDestroy() {
        GameEvents.current.OnFightZoneTriggerEnter -= startFight;
        GameEvents.current.OnFightZoneTriggerExit -= stopFight;
    }

    void startFight() {
        animator.SetBool("isIdle", false);
        animator.SetBool("isShooting", true);
        gameObject.transform.LookAt(_targetToShoot);
    }
    
    void stopFight() {
        animator.SetBool("isIdle", true);
        animator.SetBool("isShooting", false);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void setDyingTrigger()
    {
        animator.SetTrigger("die");
    }

    void resetDyingTrigger()
    {
        animator.ResetTrigger("die");
    }
}
