using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnnemy : MonoBehaviour
{
    public GameObject theEnnemy;
    public int xPos;
    public int zPos;
    public int ennemyCount;

    void Start()
    {
        StartCoroutine(EnnemyDrop());
    }
    IEnumerator EnnemyDrop(){
        while(ennemyCount<10){
            xPos = -18;
            zPos = -1;
            Vector3 v3 = new Vector3(xPos, 43, zPos);
            Instantiate(theEnnemy, v3, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            ennemyCount += 1;
        }
    }

}
