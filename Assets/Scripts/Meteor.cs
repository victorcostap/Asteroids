using System;
using Unity.VisualScripting;
using UnityEngine;

public class Meteor : PooledObject
{
    private Collider _collider;
    private Rigidbody _rigidbody;

    public int valuePoints = 100;
    
    private void Start()
    {
        _collider = gameObject.GetComponent<Collider>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            ScoreManager.instance.AddPoints(valuePoints);
            gameObject.SetActive(false);
        }
    }
}
