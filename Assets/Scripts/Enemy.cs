using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// this script is responsible for Enemy behaviour
/// 
/// @author : Martin Christian Solihin
/// </summary>


public enum ENEMY_STATE {
    IDLE,
    CHASING,
    DIE
}

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private PlayerManagement player;
    [SerializeField] private ENEMY_STATE state = ENEMY_STATE.IDLE;
    private NavMeshAgent agent;
    private MeshRenderer mesh;
    private Rigidbody rb;
    private float seeRange = 12, dieRange = 3, timer;

    private void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerManagement>();

        agent = GetComponent<NavMeshAgent>();
        mesh = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Enemy move randomly if the player out of Enemy's seeRange
    private Vector3 RandomPos() {
        Vector3 direction = UnityEngine.Random.insideUnitSphere * 50;
        direction += transform.position;
        
        NavMeshHit navHit;
        NavMesh.SamplePosition(direction, out navHit, 50, -1);

        return navHit.position;
    }

    private void Update() {
        // if the player is dead, destor enemy
        if (player.isDead)
            Destroy(gameObject);
        
        // the player is still alive and reach the see Range of enemy
        if((Vector3.Distance(transform.position, player.transform.position)) <= seeRange && !player.isDead) {
            agent.SetDestination(player.transform.position);

            if (agent.hasPath) {
                if (agent.remainingDistance <= dieRange)
                    state = ENEMY_STATE.DIE;
                else
                    state = ENEMY_STATE.CHASING;
            }
        } else {
            state = ENEMY_STATE.IDLE;
        }

        switch(state) {
            case ENEMY_STATE.IDLE:
                timer += Time.deltaTime;

                if(timer > 5) {
                    // set a random position after 5 seconds
                    agent.SetDestination(RandomPos());
                    timer = 0;
                }
                break;

            case ENEMY_STATE.DIE:
                StartCoroutine(WaitToRespawn(8));
                break;
        }
    }

    public IEnumerator WaitToRespawn(float waitTime) {
        player.LoseOneLife();

        rb.isKinematic = true;
        mesh.enabled = false;
        agent.enabled = false;
        state = ENEMY_STATE.IDLE;

        yield return new WaitForSeconds(waitTime);

        mesh.enabled = true;
        agent.enabled = true;
        rb.isKinematic = false;
    }
}
