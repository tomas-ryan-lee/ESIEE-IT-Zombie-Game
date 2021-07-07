using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnLocations;
    public GameObject[] ennemyToSpawnPrefab;
    public GameObject[] ennemyToSpawnClone;
    public int ennemyCount;
    void Start() {
        ennemyCount = 0;
        SpawnEnnemy();
    }
    private IEnumerator SpawnEnnemy(){
            if(ennemyCount<10){
                ennemyToSpawnClone[0]= Instantiate(ennemyToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,1,0)) as GameObject;
                ennemyCount += 1;
            }
             yield return new WaitForSeconds(5);
    }
}
