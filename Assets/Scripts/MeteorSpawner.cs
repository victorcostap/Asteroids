using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnPerMinute = 30;
    public float spawnRateIncrement = 1;

    private float _spawnNext = 0;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > _spawnNext){
            _spawnNext = Time.time + (60/spawnPerMinute);
            spawnPerMinute += spawnRateIncrement;

            float randX = Random.Range(-10,10);
            var spawnPosition = new Vector2(randX, 
                                            transform.position.y);
            Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(meteorPrefab);
    }
}
