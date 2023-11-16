using System;
using System.Collections.Generic;
using UnityEngine;

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

    public new Tuple<GameObject, Rigidbody> GetPooledObject()
    {
        var b = base.GetPooledObject();
        return !b ? 
            null : 
            new Tuple<GameObject, Rigidbody>(b, _object2Rb[b.GetInstanceID()]);
    }
}
