using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    public enum STATE
    {
        SEARCH, ENGAGE, IDLE
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
    protected GameObject[] idlePoints;
    protected PointOfView pointOfView;
    protected SearchArea searchArea;
    protected State nextState;
    protected NavMeshAgent agent;

    public State(GameObject _npc, Animator _anim, Transform _player, GameObject[] _idlePoints, PointOfView _pointOfView, SearchArea _searchArea, NavMeshAgent _agent)
    {
        npc = _npc;
        anim = _anim;
        player = _player;
        idlePoints = _idlePoints;
        pointOfView = _pointOfView;
        searchArea = _searchArea;
        agent = _agent;
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public State Process()
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
