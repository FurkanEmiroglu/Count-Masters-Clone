using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        GameEvents.current.OnFightZoneTriggerEnter += stopAndFight;
        GameEvents.current.OnFightZoneTriggerExit += startRunning;
    }

    void stopAndFight()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        startShootingAnimation();
    }


    void startRunning()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        stopShootingAnimation();
    }


    void startShootingAnimation()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isShooting", true);
        animator.SetBool("isIdle", false);
    }

    

    void stopShootingAnimation()
    {
        animator.SetBool("isRunning", true);
        animator.SetBool("isShooting", false);
        animator.SetBool("isIdle", false);
    }
}