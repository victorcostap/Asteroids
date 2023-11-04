using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnPerMinute = 30;
    public float spawnRateIncrement = 1;

    private float _spawnNext = 0;

    // Update is called once per frame
    private void Update()
    {
        if (Time.time < _spawnNext) return;
        
        _spawnNext = Time.time + (60/spawnPerMinute);
        spawnPerMinute += spawnRateIncrement;

        float randX = Random.Range(-10,10);
        var spawnPosition = new Vector2(randX, 
                                        transform.position.y);
        Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
    }

    private void OnBecameInvisible()
    {
        Destroy(meteorPrefab);
    }
}
