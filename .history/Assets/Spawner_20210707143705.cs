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
        //Invoke("SpawnEnnemy",3);
        //StartCoroutine(SpawnEnnemy());
    }

/*         void SpawnEnnemy(){
            if(ennemyCount < 10){
                ennemyToSpawnClone[0]= Instantiate(ennemyToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,1,0)) as GameObject;
                ennemyCount += 1;
            }
        } */

/*             private IEnumerator SpawnEnnemy(){
            while(ennemyCount < 10){
                ennemyToSpawnClone[0]= Instantiate(ennemyToSpawnPrefab[0], spawnLocations[0].transform.position, Quaternion.Euler(0,1,0)) as GameObject;
                ennemyCount += 1;
                yield return new WaitForSecondsRealtime(5);
            }
        } */

    IEnumerator SpawnEnnemy(){
        while(ennemyCount<10){
            Debug.Log(ennemyCount);
            ennemyCount += 1;
            yield return 60;
        }
    }
}
