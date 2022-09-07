using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Engage : State
{

    public Engage(GameObject _npc, Animator _anim, Transform _player, GameObject[] _idlePoints, PointOfView _pointOfView, SearchArea _searchArea, NavMeshAgent _agent) : base(_npc, _anim, _player, _idlePoints, _pointOfView, _searchArea, _agent)
    {
        name = STATE.ENGAGE;
    }

    public override void Enter()
    {
        // anim.SetTrigger("isChasing");
        Debug.Log("Engaging");
        base.Enter();
    }

    public override void Update()
    {
        if (pointOfView.InRange)
        {
            agent.SetDestination(player.position);

            Vector3 direction = player.position - npc.transform.position;
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
        }
        else
        {
            nextState = new Search(npc, anim, player, idlePoints, pointOfView, searchArea, agent);
            stage = EVENT.EXIT;
        }
    }
    
    public override void Exit()
    {
        // anim.ResetTrigger("isChasing");
        base.Exit();
    }
}
