using System;
using UnityEngine;

/// <summary>
/// Spawn Bullets when pressing space.
/// Space can be hold down and it will shoot at the specified rate.
/// </summary>
public class BulletSpawner : ObjectSpawnerRigidBodyBase
{
    /// <summary>
    /// Time between each bullets, in ms.
    /// </summary>
    public float delayMsBullet = 250;
    /// <summary>
    /// Speed of the bullet. Independent of the ship speed.
    /// </summary>
    public float bulletSpeed = 10;
    private float _spawnNext;
    private readonly Vector3 _spawnOffset = new Vector3(1,0,0);
    private Transform _tr;

    private new void Start()
    {
        base.Start();
        _tr = transform;
    }
    
    private void Update()
    {
        if (!(Input.GetKey(KeyCode.Space) && Time.time > _spawnNext)) return;
        
        _spawnNext = Time.time + delayMsBullet / 1000;
        var bulletRb = GetPooledObject();
        if (bulletRb==null) return;
        var bullet = bulletRb.Item1;
        bullet.transform.position = _tr.position +
                                    _tr.TransformDirection(_spawnOffset);
        var rb = bulletRb.Item2;
        rb.velocity = _tr.right * bulletSpeed;
        rb.rotation = Quaternion.identity;
        bullet.SetActive(true);
    }
}
