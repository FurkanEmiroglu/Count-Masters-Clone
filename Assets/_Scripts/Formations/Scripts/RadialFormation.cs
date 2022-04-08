using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadialFormation : FormationBase {
    
    [SerializeField] private float _radius = 1;
    [SerializeField] private float _radiusGrowthMultiplier = 0;
    [SerializeField] private float _rotations = 1;
    [SerializeField] private int _rings = 1;
    [SerializeField] private float _ringOffset = 1;
    [SerializeField] private float _nthOffset = 0;
    public int _amount = 1;


    private void Start()
    {
        SetParametersWithDelay();
        GameEvents.current.OnFightZoneTriggerEnter += changeBehaviourEnabled;
        GameEvents.current.OnFightZoneTriggerExit += changeBehaviourEnabled;
        GameEvents.current.OnFightZoneTriggerExit += SetParametersWithDelay;
    }


    public override IEnumerable<Vector3> EvaluatePoints() {
        var amountPerRing = _amount / _rings;
        var ringOffset = 0f;
        for (var i = 0; i < _rings; i++) {
            for (var j = 0; j < amountPerRing; j++) {
                var angle = j * Mathf.PI * (2 * _rotations) / amountPerRing + (i % 2 != 0 ? _nthOffset : 0);

                var radius = _radius + ringOffset + j * _radiusGrowthMultiplier;
                var x = Mathf.Cos(angle) * radius;
                var z = Mathf.Sin(angle) * radius;

                var pos = new Vector3(x, 0, z);

                pos += GetNoise(pos);

                pos *= Spread;

                yield return pos;
            }

            ringOffset += _ringOffset;
        }
    }
    public (float, int, float) determineParameters(int amount) {
        // ToDo: There must be a better way to do this
        if (amount == 1) {
            return (0, 1, 0);
        }
        else if (amount < 6) {
            return (0.25f, 1, 0);
        }
        else if (amount < 11) {
            return (0.5f, 1, 0);
        }
        else if (amount < 21) {
            return (0.4f, 2, 0.25f);
        }
        else if (amount < 41) {
            return (0.5f, 2, 0.3f);
        }
        else if (amount < 71) {
            return (0.6f, 3, .3f);
        }
        else if (amount < 100) {
            return (.6f, 4, .3f);
        }
        else if (amount < 150) {
            return (.6f, 5, .3f);
        }
        else if (amount < 200) {
            return (.6f, 6, .3f);
        }
        else if (amount < 300) {
            return (.6f, 7, .3f);
        }
        else {
            Debug.LogWarning("Couldn't find a list for _amount");
            return (0, 0, 0);
        }
    }

    private void getParameters() {
        (var radius, var rings, var ringsoffset) = determineParameters(_amount);
    }

    public void SetParametersWithDelay() {
        Invoke("SetParameters", 0.2f);
    }

    private void SetParameters() {
        (_radius, _rings, _ringOffset) = determineParameters(_amount);
    }

    private void changeBehaviourEnabled() {
        enabled = !enabled;
    }
}