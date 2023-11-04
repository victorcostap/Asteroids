using System;
using UnityEngine;

public class BulletSpawner : ObjectSpawnerBase
{
    public float delayMsBullet = 250;
    public float bulletSpeed = 10;
    private float _spawnNext;
    private Vector3 _spawnOffset = new Vector3(1,0,0);

    private void Update()
    {
        if (!(Input.GetKey(KeyCode.Space) && Time.time > _spawnNext)) return;
        
        _spawnNext = Time.time + delayMsBullet / 1000;
        var bullet = GetPooledObject();
        if (!bullet) return;
        bullet.transform.position = transform.position +
                                    transform.TransformDirection(_spawnOffset);
        var rb = bullet.GetComponent<Rigidbody>();
        //rb.AddForce(transform.right * bulletSpeed);
        rb.velocity = transform.right * bulletSpeed;
        rb.rotation = Quaternion.identity;
        bullet.SetActive(true);
    }
}
