using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FriendlyArmy : MonoBehaviour {
    private FormationBase _formation;

    public FormationBase Formation {
        get {
            if (_formation == null) _formation = GetComponent<FormationBase>();
            return _formation;
        }
        set => _formation = value;
    }

    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private float _unitSpeed = 2;

    public readonly List<GameObject> spawnedUnits = new List<GameObject>();
    private List<Vector3> _points = new List<Vector3>();
    private Transform _parent;
    private RadialFormation friendlyFormation;
    private void Start()
    {
        _parent = ObjectPooler.Instance.MainCharacter.transform;
        friendlyFormation = ObjectPooler.Instance.formation;
        GameEvents.current.OnFightZoneTriggerEnter += changeBehaviourEnabled;
        GameEvents.current.OnFightZoneTriggerExit += changeBehaviourEnabled;
    }

    private void Update() {
        SetFormation();
    }

    void SetFormation() {
        _points = Formation.EvaluatePoints().ToList();
        if (_points.Count > spawnedUnits.Count) {
            var remainingPoints = _points.Skip(spawnedUnits.Count);
            Spawn(remainingPoints);
        } 
        else if (_points.Count < spawnedUnits.Count) {
            KillRandom(spawnedUnits.Count - _points.Count);
        }

        for (var i = 0; i < spawnedUnits.Count; i++) {
            spawnedUnits[i].transform.position = Vector3.MoveTowards(spawnedUnits[i].transform.position, transform.position + _points[i], _unitSpeed * Time.deltaTime);
        }
    }

    void Spawn(IEnumerable<Vector3> points) {
        foreach (var pos in points)
        {
            var unit = ObjectPooler.Instance.SpawnFromPool("CloneCharacter", transform.position + pos, Quaternion.identity, _parent);
            spawnedUnits.Add(unit);
        }
    }

    public void KillRandom(int num) {
        for (var i = 0; i < num; i++) {
            var unit = spawnedUnits.Last();
            spawnedUnits.Remove(unit);
            ObjectPooler.Instance.ReturnToPool("CloneCharacter", unit);
        }
    }

    /*public void KillSpecific(GameObject obj) {
        spawnedUnits.Remove(obj);
        ObjectPooler.Instance.ReturnToPool("CloneCharacter", obj);
    }*/


    private void changeBehaviourEnabled()
    {
        enabled = !enabled;
    }
}