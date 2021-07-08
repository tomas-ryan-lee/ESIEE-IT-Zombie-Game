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
    bool playerInRange;
    float AttackDistance = 1.5f;
    float playerHealth = 100;
    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("Player");
        target = GetClosestEnemy(players).transform;
        playerInRange = false;
    }

    void FixedUpdate()
    {
        if(target == null){
            players = GameObject.FindGameObjectsWithTag("Player");
            target = GetClosestEnemy(players).transform;
        }
        target = GetClosestEnemy(players).transform;
        if (Vector3.Distance(transform.position, target.position) > AttackDistance)
        {
            // Move towards the player
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            agent.SetDestination(pos);
        }
        else
        {
            // Attack the player
            StartCoroutine(Attack());
        }
    }

    GameObject GetClosestEnemy(GameObject[] players)
    {
        GameObject nearestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potentialTarget in players)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                nearestTarget = potentialTarget;
            }
        }
        return nearestTarget;
    }
    IEnumerator Attack()
    {
        Debug.Log(playerHealth);
        playerHealth -= 7;
        if(playerHealth <= 0){
            // Player is destroyed, ennemy switch target
            Object.Destroy(target.gameObject);
            target = GetClosestEnemy(players).transform;
        }
        Debug.Log(playerHealth);
        Debug.Log("wait until next attack");
        yield return new WaitForSeconds(5);
    }
}
