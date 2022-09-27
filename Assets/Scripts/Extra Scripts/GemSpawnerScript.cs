using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawnerScript : MonoBehaviour {
    
    public GameObject[] gemPrefab; 


    public float gemSpawnTimer = 12.0f;
    private float currentGST;

    // private int gemSpawnCount;
    public float minBoundX = -2.0f, maxBoundX = 2.0f;

    void Start() {
        currentGST = gemSpawnTimer;
    }

    void Update() {
        SpawnGems();
    }

    void SpawnGems() {
        currentGST += Time.deltaTime;

        if(currentGST >= gemSpawnTimer) {

            Vector3 temp = transform.position;
            temp.x = Random.Range(minBoundX, maxBoundX);

            GameObject newGem = null;
            newGem = Instantiate(gemPrefab[Random.Range(0, gemPrefab.Length)], temp, Quaternion.identity);
            
            if(newGem)
                newGem.transform.parent = transform;
            currentGST = 0.0f;
        }
    }
}
