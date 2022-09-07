using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateBoss
{
    public enum STATE
    {
        ENGAGE, REST, SPAWN
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected StateBoss nextState;
    protected NavMeshAgent agent;
    protected GameObject[] spawnPoints;
    protected GameObject minion;
    protected float timer;

    public StateBoss(GameObject _npc, Animator _anim, Transform _player, NavMeshAgent _agent, GameObject[] _spawnPoints, GameObject _minion)
    {
        npc = _npc;
        anim = _anim;
        player = _player;
        agent = _agent;
        spawnPoints = _spawnPoints;
        minion = _minion;
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public StateBoss Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }
}
