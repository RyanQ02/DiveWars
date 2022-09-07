using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnBoss : StateBoss
{
    public SpawnBoss(GameObject _npc, Animator _anim, Transform _player, NavMeshAgent _agent, GameObject[] _spawnPoints, GameObject _minion) : base(_npc, _anim, _player, _agent, _spawnPoints, _minion)
    {
        timer = 4f;
        name = STATE.SPAWN;

        // Cycle through array and spawn fish
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject.Instantiate(minion, spawnPoints[i].transform.position, Quaternion.identity);
        }
    }

    public override void Enter()
    {
        Debug.Log("BossSpawn");
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
            nextState = new EngageBoss(npc, anim, player, agent, spawnPoints, minion);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
