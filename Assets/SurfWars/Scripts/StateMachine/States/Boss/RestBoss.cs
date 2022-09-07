using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RestBoss : StateBoss
{

    public RestBoss(GameObject _npc, Animator _anim, Transform _player, NavMeshAgent _agent, GameObject[] _spawnPoints, GameObject _minion) : base(_npc, _anim, _player, _agent, _spawnPoints, _minion)
    {
        agent.isStopped = true;
        timer = 3f;
        name = STATE.REST;
    }

    public override void Enter()
    {
        Debug.Log("BossRest");
        base.Enter();
    }

    public override void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            nextState = new SpawnBoss(npc, anim, player, agent, spawnPoints, minion);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
