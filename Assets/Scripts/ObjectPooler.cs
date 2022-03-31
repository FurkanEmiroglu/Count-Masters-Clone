using System.Collections.Generic;
using UnityEngine;

// . . There are 2 pools in this game. First one is activePool and second one is 


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

    void OnEnable()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {

                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.parent = this.transform;
                objectPool.Enqueue(obj);

            }

            poolDictionary.Add(pool.tag, objectPool);

        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform parent)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Key doesn't exist in objectPooler: " + tag);
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.transform.parent = parent;

        return objectToSpawn;
    }

    public void ReturnToPool(string tag, GameObject objectToPool)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Key doesn't exist in poolDictionary: " + tag);
        }

        objectToPool.SetActive(false);
        objectToPool.transform.parent = this.transform;
        poolDictionary[tag].Enqueue(objectToPool);
    }
}
