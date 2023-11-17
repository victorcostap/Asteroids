using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorSpawner : ObjectSpawnerRigidBodyBase
{
    private float _spawnNext;
    private Camera _camera;
    
    public float spawnRatePerMinute = 30;
    public float maxSpawnRatePerMinute = 60;
    public float spawnRateIncrement = 1;
    public float minVelocitySpawn = 0;
    public float maxVelocitySpawn = 10;
    
    private new void Start()
    {
        _camera = Camera.main;
        if (_camera == null)
        {
            Debug.LogError("No main camera found.");
            return;
        }
        
        base.Start();
    }
    
    private (Vector3, Vector3) GetCameraWorldPoint()
    {
        var screenWidth = _camera.pixelWidth;
        var screenHeight = _camera.pixelHeight;
        
        var screenMin = _camera.ScreenToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
        var screenMax = _camera.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, _camera.nearClipPlane));

        return (screenMin, screenMax);
    }
    
    private void SpawnMeteor()
    {
        _spawnNext = Time.time + (60/spawnRatePerMinute);
        spawnRatePerMinute = Math.Min(spawnRatePerMinute + spawnRateIncrement,
            maxSpawnRatePerMinute);
        
        var (screenMin, screenMax) = GetCameraWorldPoint();
        
        var randX = Random.Range(screenMin.x, screenMax.x);
        var spawnPosition = new Vector2(randX, transform.position.y);
        var meteorRb = GetPooledObject();
        if (meteorRb==null) return;
        var rb = meteorRb.Item2;
        rb.velocity = new Vector3(0, -Random.Range(minVelocitySpawn, maxVelocitySpawn), 0);
        var obj = meteorRb.Item1;
        obj.transform.position = spawnPosition;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (Time.time < _spawnNext) return;
        
        SpawnMeteor();
    }
}