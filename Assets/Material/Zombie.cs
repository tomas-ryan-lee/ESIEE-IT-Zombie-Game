using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Variables
    public Transform target;
    public float speed = 4f;
    Rigidbody rig;
    void Start() {
        rig=GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        // Make the ennemy moves toward the player
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed*Time.fixedDeltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
        
    }
}
