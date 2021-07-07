using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    public NavMeshAgent agent; 
    Rigidbody rig;
    public GameObject[] players;
    void Awake() {
        rig=GetComponent<Rigidbody>();
        agent=GetComponent<NavMeshAgent>();
        //target = GameObject.FindWithTag("Player").transform;
        players = GameObject.FindGameObjectsWithTag("Player");
        target = GetClosestEnemy(players).transform;
    }

    void FixedUpdate() {
        // Make the zombie moves toward the player
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed*Time.fixedDeltaTime);
        agent.SetDestination(pos);
    }

    GameObject GetClosestEnemy (GameObject[] players)
    {
        GameObject nearestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(GameObject potentialTarget in players)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                nearestTarget = potentialTarget;
            }
        }
     
        return nearestTarget;
    }
}
