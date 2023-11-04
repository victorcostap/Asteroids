using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerBase : MonoBehaviour
{
    public GameObject objectPrefab;
    public uint maxObjects = 10;
    private List<GameObject> _objectPool = new List<GameObject>();
    private List<int> _availableObjects = new List<int>();
    
    public float spawnRatePerMinute = 30;
    public float maxSpawnRatePerMinute = 60;
    public float spawnRateIncrement = 1;

    protected void Start()
    {
        for (var i = 0; i < maxObjects; ++i)
        {
            var obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            obj.GetComponent<PooledObject>().Initialize(this);
            _objectPool.Add(obj);
            _availableObjects.Add(i);
        }
    }
    
    public GameObject GetPooledObject()
    {
        if (_availableObjects.Count == 0) return null;

        var i = _availableObjects[0];
        _availableObjects.RemoveAt(0);
        return _objectPool[i];
    }

    public void ReturnToPool(GameObject obj)
    {
        var i = _objectPool.IndexOf(obj);
        if (i == -1) return;
        
        obj.SetActive(false);
        _availableObjects.Add(i);
    }
}
