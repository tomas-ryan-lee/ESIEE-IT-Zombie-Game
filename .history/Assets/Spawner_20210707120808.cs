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
        Invoke("SpawnEnnemy", 4);
        
    }
    void Update()
    {
        //StartCoroutine(SpawnEnnemy());
    }

        void SpawnEnnemy(){
            if(ennemyCount<10){
                ennemyToSpawnClone[0]= Instantiate(ennemyToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,1,0)) as GameObject;
                ennemyCount += 1;
            }
    }
/*     private IEnumerator SpawnEnnemy(){
            if(ennemyCount<10){
                ennemyToSpawnClone[0]= Instantiate(ennemyToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,1,0)) as GameObject;
                ennemyCount += 1;
                yield return new WaitForSeconds(5);
            }
             
    } */
}
