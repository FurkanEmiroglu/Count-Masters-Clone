using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFighting : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    private void Start() {
        targetTransform = ObjectPooler.Instance.MainCharacter.transform;
    }

    private void FixedUpdate()
    {
        cameraActionSequence();
        GameEvents.current.OnFightZoneTriggerEnter += goFightingMode;
        GameEvents.current.OnFightZoneTriggerExit += goRunningMode;
    }

    private void cameraActionSequence()
    {
        Vector3 desiredPosition = targetTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(transform);
    }

    void goFightingMode()
    {
        enabled = true;
    }

    void goRunningMode()
    {
        enabled = false;
    }
}
