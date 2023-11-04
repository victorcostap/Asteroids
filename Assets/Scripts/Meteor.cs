using System;
using Unity.VisualScripting;
using UnityEngine;

public class Meteor : PooledObject
{
    private Collider _collider;
    private Rigidbody _rigidbody;
    
    private void Start()
    {
        _collider = gameObject.GetComponent<Collider>();
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }
    
    private new void OnBecameInvisible()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.rotation = Quaternion.identity;
        base.OnBecameInvisible();
    }
}
