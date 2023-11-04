using System;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private ObjectSpawnerBase _objectSpawnerBase;

    public void Initialize(ObjectSpawnerBase spawnerBase)
    {
        _objectSpawnerBase = spawnerBase;
    }

    protected void OnBecameInvisible()
    {
        if (_objectSpawnerBase != null)
        {
            _objectSpawnerBase.ReturnToPool(gameObject);
        }
    }
}
