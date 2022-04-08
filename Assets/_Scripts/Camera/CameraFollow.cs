using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 _currentOffset;
    [SerializeField] private Vector3 _currentRotation;
    [SerializeField] private Vector3 _runningOffset;
    [SerializeField] private Vector3 _runningRotation;
    [SerializeField] private Vector3 _fightingOffset;
    [SerializeField] private Vector3 _fightingRotation;
    [SerializeField] private Vector3 _celebrateOffset;
    [SerializeField] private Vector3 _celebrateRotation;


    private void Start()
    {
        targetTransform = ObjectPooler.Instance.MainCharacter.transform;
        _currentOffset = _runningOffset;
        _currentRotation = _runningRotation;
        GameEvents.current.OnFightZoneTriggerEnter += changeToFightingCam;
        GameEvents.current.OnFightZoneTriggerExit += changeToRunningCam;
        GameEvents.current.onLevelComplete += changeToCelebratingCam;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = targetTransform.position + _currentOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

        Quaternion desiredRotation = Quaternion.Euler(_currentRotation);
        Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, _smoothSpeed);

        transform.position = smoothedPosition;
        transform.rotation = smoothedRotation;
        transform.LookAt(transform);
    }

    private void changeToFightingCam()
    {
        _currentOffset = _fightingOffset;
        _currentRotation = _fightingRotation;
    }

    private void changeToRunningCam()
    {
        _currentOffset = _runningOffset;
        _currentRotation = _runningRotation;
    }

    private void changeToCelebratingCam() {
        _currentOffset = _celebrateOffset;
        _currentRotation = _celebrateRotation;
    }
}

