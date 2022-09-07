using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EngageBoss : StateBoss
{

    public EngageBoss(GameObject _npc, Animator _anim, Transform _player, NavMeshAgent _agent, GameObject[] _spawnPoints, GameObject _minion) : base(_npc, _anim, _player, _agent, _spawnPoints, _minion)
    {
        timer = 5f;
        agent.isStopped = false;
        name = STATE.ENGAGE;
    }

    public override void Enter()
    {
        Debug.Log("BossEngaging");
        base.Enter();
    }

    public override void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            agent.SetDestination(player.position);
        }
        else
        {
            nextState = new RestBoss(npc, anim, player, agent, spawnPoints, minion);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
