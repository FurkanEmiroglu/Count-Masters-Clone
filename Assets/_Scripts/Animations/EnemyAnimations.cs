using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    Animator animator;

    // this controller is for enemy units
    private void Start() {
        animator = GetComponentInChildren<Animator>();
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
    }
    
    void stopFight() {
        animator.SetBool("isIdle", true);
        animator.SetBool("isShooting", false);
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
