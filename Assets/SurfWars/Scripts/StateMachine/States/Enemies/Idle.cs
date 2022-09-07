using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    int currentIndex = 0;

    public Idle(GameObject _npc, Animator _anim, Transform _player, GameObject[] _idlePoints, PointOfView _pointOfView, SearchArea _searchArea, NavMeshAgent _agent) : base(_npc, _anim, _player, _idlePoints, _pointOfView, _searchArea, _agent)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        // anim.SetTrigger("isChasing");
        Debug.Log("Idle");
        base.Enter();
    }

    public override void Update()
    {

        agent.SetDestination(idlePoints[currentIndex].transform.position);

        Vector3 direction = idlePoints[currentIndex].transform.position - npc.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        npc.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (npc.transform.eulerAngles.z + 90 >= 180 || npc.transform.eulerAngles.z + 90 <= 0)
        {
            npc.transform.localScale = new Vector3(1, -1, 1);
        }
        else if (npc.transform.eulerAngles.z + 90 < 180 || npc.transform.eulerAngles.z + 90 > 0)
        {
            npc.transform.localScale = new Vector3(1, 1, 1);
        }

        float distance = Vector2.Distance(npc.transform.position, idlePoints[currentIndex].transform.position);

        if (distance <= 0.05)
        {
            if (currentIndex >= idlePoints.Length - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
        }

        if (pointOfView.InRange)
        {
            nextState = new Engage(npc, anim, player, idlePoints, pointOfView, searchArea, agent);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        // anim.ResetTrigger("isChasing");
        base.Exit();
    }
}
