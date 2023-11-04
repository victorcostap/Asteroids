using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorSpawner : ObjectSpawnerBase
{
    private float _spawnNext;

    /*private Vector2 _screenBounds;
    private void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, 
                              Screen.height, 
                                Camera.main.transform.position.z));
    }*/

    // Update is called once per frame
    private void Update()
    {
        if (Time.time < _spawnNext) return;
        
        _spawnNext = Time.time + (60/spawnRatePerMinute);
        spawnRatePerMinute = Math.Min(spawnRatePerMinute + spawnRateIncrement,
                                      maxSpawnRatePerMinute);

        float randX = Random.Range(-10,10);
        var spawnPosition = new Vector2(randX, 
                                        transform.position.y);
        var obj = GetPooledObject();
        if (!obj) return;
        
        obj.transform.position = spawnPosition;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);
    }
}
