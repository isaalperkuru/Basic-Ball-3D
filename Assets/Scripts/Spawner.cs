using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float additionalSpawnTime = 3f;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform[] spawnPositions;
    private TimeManager2 timeManager;
    private float spawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<TimeManager2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad >= spawnTime 
            && timeManager.gameOver == false 
            && timeManager.isFinished == false)
        {
            spawnTime += additionalSpawnTime;
            SpawnPrefab(prefabs[RandomNumberGenerator(prefabs.Length)], spawnPositions[RandomNumberGenerator(spawnPositions.Length)]);
        }
    }

    private void SpawnPrefab(GameObject prefab, Transform newPosition)
    {
        Instantiate(prefab, newPosition.position, newPosition.rotation);
    }
    private int RandomNumberGenerator(int size)
    {
        return Random.Range(0, size);
    }
}
