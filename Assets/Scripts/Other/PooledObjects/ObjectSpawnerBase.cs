using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles pooling objects. This avoids the need to instantiate and destroy objects, improving performance.
/// This class must be inherited by another one that implements the logic of where and how to spawn the object.
/// </summary>
public abstract class ObjectSpawnerBase: MonoBehaviour
{
    /// <summary>
    /// Object to spawn
    /// </summary>
    public GameObject objectPrefab;
    /// <summary>
    /// Size of the pool
    /// </summary>
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
    
    /// <summary>
    /// Returns a object available in the Pool. If there are none left, return null
    /// </summary>
    /// <returns>GameObject if there are available objects in the pool, null otherwise</returns>
    public GameObject GetPooledObject()
    {
        if (_availableObjects.Count == 0) return null;
        
        var id = _availableObjects.Dequeue();
        return _objectPool[id];
    }
    
    /// <summary>
    /// Returns an object to the Pool
    /// </summary>
    /// <param name="obj">GameObject to return</param>
    public void ReturnToPool(GameObject obj)
    {
        var id = obj.GetInstanceID();
        if (!_objectPool.ContainsKey(id)) return;
        
        obj.SetActive(false);
        _availableObjects.Enqueue(id);
    }
}
