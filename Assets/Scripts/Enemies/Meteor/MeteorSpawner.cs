using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Spawn Meteors inside the screen.
/// </summary>
public class MeteorSpawner : ObjectSpawnerRigidBodyBase
{
    private float _spawnNext;
    private Camera _camera;
    
    /// <summary>
    /// Initial number of Meteors to spawn per minute
    /// </summary>
    public float spawnRatePerMinute = 30;
    /// <summary>
    /// Max number of spawn per minute
    /// </summary>
    public float maxSpawnRatePerMinute = 60;
    /// <summary>
    /// Increase spawn rate value per each time a Meteor is spawned
    /// </summary>
    public float spawnRateIncrement = 1;
    /// <summary>
    /// Min range of velocity a Meteor can have when spawning
    /// </summary>
    public float minVelocitySpawn = 0;
    /// <summary>
    /// Max range of velocity a Meteor can have when spawning
    /// </summary>
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
    
    /// <summary>
    /// Gets the screen size in world point (coordinate reference instead of pixels)
    /// </summary>
    /// <returns>Tuple with the coordinates of the bottom left and the top right of the screen</returns>
    private (Vector3, Vector3) GetCameraWorldPoint()
    {
        var screenWidth = _camera.pixelWidth;
        var screenHeight = _camera.pixelHeight;
        
        var screenMin = _camera.ScreenToWorldPoint(new Vector3(0, 0, _camera.nearClipPlane));
        var screenMax = _camera.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, _camera.nearClipPlane));

        return (screenMin, screenMax);
    }
    
    /// <summary>
    /// Generate a Meteor at the top of the screen and with the X randmly inside the screen.
    /// </summary>
    private void SpawnMeteor()
    {
        _spawnNext = Time.time + (60/spawnRatePerMinute);
        spawnRatePerMinute = Math.Min(spawnRatePerMinute + spawnRateIncrement,
            maxSpawnRatePerMinute);
        
        var (screenMin, screenMax) = GetCameraWorldPoint();
        
        var randX = Random.Range(screenMin.x, screenMax.x);
        var spawnPosition = new Vector3(randX, transform.position.y, gameObject.transform.position.z);
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
