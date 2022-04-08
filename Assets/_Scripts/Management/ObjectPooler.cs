using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    // Throw these objects to variables inside the inspector
    public GameObject MainCharacter;
    public GameObject EnemyMain;
    public GameObject area;

    // these ones below will be detected OnEnable, they are public so other objects can pull
    public RadialFormation formation;
    public RadialFormation enemyFormation;
    public FriendlyArmy friendlyArmy;
    public EnemyArmy enemyArmy;
    public ShootOut shootOutScript;

    void OnEnable() {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.parent = this.transform;
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
        formation = MainCharacter.GetComponent<RadialFormation>();
        friendlyArmy = MainCharacter.GetComponent<FriendlyArmy>();
        enemyFormation = EnemyMain.GetComponent<RadialFormation>();
        enemyArmy = EnemyMain.GetComponent<EnemyArmy>();
        shootOutScript = area.GetComponentInChildren<ShootOut>();
    }

    // spawning from the pool
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parent) {
        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Key doesn't exist in objectPooler: " + tag);
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.transform.parent = parent;
        return objectToSpawn;
    }


    // returning to pool
    public void ReturnToPool(string tag, GameObject objectToPool) {
        if (!poolDictionary.ContainsKey(tag)) {
            Debug.LogWarning("Key doesn't exist in poolDictionary: " + tag);
        }
        objectToPool.SetActive(false);
        objectToPool.transform.parent = this.transform;
        poolDictionary[tag].Enqueue(objectToPool);
    }
}
