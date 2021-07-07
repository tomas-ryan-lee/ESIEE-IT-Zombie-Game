using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    private float dist;
    public float howClose;
    public NavMeshAgent agent; 
    Rigidbody rig;
    void Awake() {
        rig=GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;


    }

    void FixedUpdate() {
        dist = Vector3.Distance(target.position, transform.position);
        if(dist <= howClose){
            transform.LookAt(target);
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }
        if(dist <= 1.5f){
            // Do damage
        }
        // Make the zombie moves toward the player
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed*Time.fixedDeltaTime);
        /*rig.MovePosition(pos);
        transform.LookAt(target); */
        agent.SetDestination(pos);
        
    }
}
