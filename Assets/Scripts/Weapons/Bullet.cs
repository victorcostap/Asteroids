using System;
using UnityEngine;

public class Bullet : PooledObject
{
    private Rigidbody _rigidbody;
    
    private void Start()
    {
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    private new void ReturnToPool()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.rotation = Quaternion.identity;
        base.ReturnToPool();
    }
    
    private new void OnBecameInvisible()
    {
        ReturnToPool();
    }
}
