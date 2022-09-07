using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavStateMachine : MonoBehaviour
{
    public float speed = 0.3f;
    public Transform player;
    public GameObject[] idlePoints;
    public SearchArea searchArea;

    NavMeshAgent agent;
    Animator anim;
    State currentState;
    PointOfView pointOfView;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;

        anim = this.GetComponent<Animator>();
        pointOfView = this.GetComponentInChildren<PointOfView>();

        currentState = new Idle(this.gameObject, anim, player, idlePoints, pointOfView, searchArea, agent);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }
}
