using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float _swingDelay;

    private void Start() {
        StartCoroutine(startSwingAfter(_swingDelay));
    }

    private IEnumerator startSwingAfter(float time) {
        yield return new WaitForSeconds(time);
        StartSwinging();
    }

    private void StartSwinging() {
        animator.SetTrigger("startRunning");
    }
}
