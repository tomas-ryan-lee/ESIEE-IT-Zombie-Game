using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] ennemyToSpawnPrefab;
    public GameObject[] ennemyToSpawnClone;
    public int ennemyCount;
    void Start() {
        ennemyCount = 0;
        StartCoroutine(SpawnEnnemy());
    }
    void Update()
    {
        SpawnEnnemy();
    }

    IEnumerator SpawnEnnemy(){
        while(ennemyCount<12){
            ennemyToSpawnClone[0]= Instantiate(ennemyToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,1,0)) as GameObject;
            ennemyToSpawnClone[0]= Instantiate(ennemyToSpawnPrefab[1], spawnLocations[1].transform.position, Quaternion.Euler(0,1,0)) as GameObject;
            ennemyToSpawnClone[0]= Instantiate(ennemyToSpawnPrefab[0], spawnLocations[2].transform.position, Quaternion.Euler(0,1,0)) as GameObject;
            ennemyCount += 3;
            yield return new WaitForSeconds(3);
        }
    }
}
