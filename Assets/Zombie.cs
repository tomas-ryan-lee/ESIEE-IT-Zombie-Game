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
    void Awake() {
        rig=GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        // Make the zombie moves toward the player
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed*Time.fixedDeltaTime);
        /*rig.MovePosition(pos);
        transform.LookAt(target); */
        agent.SetDestination(pos);
        
    }
}
