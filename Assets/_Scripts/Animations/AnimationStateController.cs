using UnityEngine;
using System.Collections;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    Transform _targetToShoot;
   
    
    // this controller is for friendlyUnits
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        _targetToShoot = ObjectPooler.Instance.EnemyMain.transform;
        GameEvents.current.OnFightZoneTriggerEnter += stopAndFight;
        GameEvents.current.OnFightZoneTriggerExit += startRunning;
        GameEvents.current.OnFightZoneTriggerExit += resetDyingTrigger;
        GameEvents.current.onLevelComplete += setDancingTrigger;
    }

    void stopAndFight() {
        startShootingAnimation();
        gameObject.transform.LookAt(_targetToShoot);
    }


    void startRunning() {
        stopShootingAnimation();
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }


    void startShootingAnimation() {
        animator.SetBool("isRunning", false);
        animator.SetBool("isShooting", true);
        animator.SetBool("isIdle", false);
    }

    void stopShootingAnimation() {
        animator.SetBool("isRunning", true);
        animator.SetBool("isShooting", false);
        animator.SetBool("isIdle", false);
    }

    public void setDyingTrigger() {
        animator.SetTrigger("die");
    }

    void resetDyingTrigger() {
        animator.ResetTrigger("die");
    }

    void setDancingTrigger() {
        animator.SetTrigger("dance");
    }

    void resetDancingTrigger() {
        animator.ResetTrigger("dance");
    }
}