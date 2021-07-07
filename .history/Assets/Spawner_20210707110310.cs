using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] ennemyToSpawnPrefab;
    public GameObject[] ennemyToSpawnClone;
    public int ennemyCount;
    public float timeStamp;
    void Start() {
        timeStamp = Time.time + 2;
        ennemyCount = 0;
        SpawnEnnemy();
    }
    void SpawnEnnemy(){
        if (timeStamp <= Time.time)
        {
            ennemyToSpawnClone[0]= Instantiate(ennemyToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,1,0)) as GameObject;
            ennemyCount += 1;
        }
    }
}
