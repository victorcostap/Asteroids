using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerBase: MonoBehaviour
{
    public GameObject objectPrefab;
    public uint maxObjects = 10;

    private readonly Queue<int> _availableObjects = new Queue<int>();
    private readonly Dictionary<int, GameObject> _objectPool = new Dictionary<int, GameObject>();
    
    protected void Start()
    {
        for (var i = 0; i < maxObjects; ++i)
        {
            var obj = Instantiate(objectPrefab);
            var id = obj.GetInstanceID();
            obj.SetActive(false);
            obj.GetComponent<PooledObject>().Initialize(this);
            _objectPool.Add(id, obj);
            _availableObjects.Enqueue(id);
        }
    }
    
    public GameObject GetPooledObject()
    {
        if (_availableObjects.Count == 0) return null;
        
        var id = _availableObjects.Dequeue();
        return _objectPool[id];
    }

    public void ReturnToPool(GameObject obj)
    {
        var id = obj.GetInstanceID();
        if (!_objectPool.ContainsKey(id)) return;
        
        obj.SetActive(false);
        _availableObjects.Enqueue(id);
    }
}
