using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Specialization of ObjectSpawnerBase to handle objects with RigidBody components.
/// This avoids having to get the RigidBody component each time is required.
/// </summary>
public class ObjectSpawnerRigidBodyBase : ObjectSpawnerBase
{
    
    private Dictionary<int, Rigidbody> _object2Rb = new Dictionary<int, Rigidbody>();
    
    protected new void Start()
    {
        base.Start();
        for (uint i = 0; i < base.maxObjects; ++i)
        {
            var b = base.GetPooledObject();
            var rb = b.GetComponent<Rigidbody>();
            _object2Rb.Add(b.GetInstanceID(), rb);
            ReturnToPool(b);
        }
    }
    
    /// <summary>
    /// Returns an object from the pool and its associated RigidBody.
    /// If there are no objects left in the pool, return null.
    /// </summary>
    /// <returns>Tuple of the GameObject and its RigidBody if there are available objects in the pool, null otherwise</returns>
    public new Tuple<GameObject, Rigidbody> GetPooledObject()
    {
        var b = base.GetPooledObject();
        return !b ? 
            null : 
            new Tuple<GameObject, Rigidbody>(b, _object2Rb[b.GetInstanceID()]);
    }
}
