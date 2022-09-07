using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshAI : MonoBehaviour {

    private PlayerController thePlayer;
    public GameObject death;

    public float speed = 0.3f;

    private float turnTimer;
    public float timeTrigger;

    private Rigidbody2D myRigidbody;

    [SerializeField] private Transform target;
    private NavMeshAgent agent;
	
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
	
    void Update (){
        agent.SetDestination(target.position);
    }
}