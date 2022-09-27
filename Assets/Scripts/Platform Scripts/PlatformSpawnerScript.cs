using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour {
    
    public GameObject platformPrefab;
    public GameObject spikePrefab;
    public GameObject glassPrefab;
    public GameObject[] speedPrefab;


    public float platformSpawnTimer = 1.0f;
    private float currentPST;

    private int platformSpawnCount;
    public float minBoundX = -3.5f, maxBoundX = 3.5f;

    void Start() {
        currentPST = platformSpawnTimer;
    }

    void Update() {
        SpawnPlatforms();
    }

    void SpawnPlatforms() {
        currentPST += Time.deltaTime;

        if(currentPST >= platformSpawnTimer) {
            platformSpawnCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(minBoundX, maxBoundX);

            GameObject newPlatform = null;

            if(platformSpawnCount < 1) {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            } else if(platformSpawnCount == 1) {
                if(Random.Range(0,2) > 0) {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                } else {
                    newPlatform = Instantiate(speedPrefab[Random.Range(0, speedPrefab.Length)], temp, Quaternion.identity);
                }
            } else if(platformSpawnCount == 2) {
                if(Random.Range(0,2) > 0) {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                } else {
                    newPlatform = Instantiate(spikePrefab, temp, Quaternion.identity);
                }
            } else if(platformSpawnCount == 3) {
                if(Random.Range(0,2) > 0) {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                } else {
                    newPlatform = Instantiate(glassPrefab, temp, Quaternion.identity);
                }
                platformSpawnCount = 0;
            }

            if(newPlatform)
                newPlatform.transform.parent = transform;
            currentPST = 0.0f;
        }
    }
}
