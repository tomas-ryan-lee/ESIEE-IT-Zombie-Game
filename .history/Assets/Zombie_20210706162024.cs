using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    // Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float health;

    // States
    public float attackRange;
    public bool playerInAttackRange;
    private void Awake(){
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update() {
        // Check if a player is in sight or in attack range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        if(playerInAttackRange)AttackPlayer();
    }
    private void AttackPlayer(){
        // Zombie must not move when attacking
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if(!alreadyAttacked){
            // ATTACK  CODE HERE
            // PLAYER LOOSE HEALTH
            alreadyAttacked=true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack(){
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage){
        health = health - damage;
        if(health<0)Invoke(nameof(EnnemyDie),2f);
    }
    private void EnnemyDie(){
        Destroy(gameObject);
    }

}
