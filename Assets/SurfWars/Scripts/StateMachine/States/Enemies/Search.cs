using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Search : State
{
    SearchArea thisSearchArea;
    Vector3[] points;
    int numPoints = 5;
    int currentIndex = 0;

    public Search(GameObject _npc, Animator _anim, Transform _player, GameObject[] _idlePoints, PointOfView _pointOfView, SearchArea _searchArea, NavMeshAgent _agent) : base(_npc, _anim, _player, _idlePoints, _pointOfView, _searchArea, _agent)
    {
        name = STATE.SEARCH;
    }

    public override void Enter()
    {
        // Spawn search area
        thisSearchArea = GameObject.Instantiate(searchArea, npc.transform.position, Quaternion.identity);
        // anim.SetTrigger("isSearching");

        // Create array of search points
        points = new Vector3[numPoints];
        for (int i = 0; i < points.Length; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle * thisSearchArea.GetComponent<CircleCollider2D>().radius;
            Vector3 offSet = new Vector3(randomPoint.x, randomPoint.y, 0);
            points[i] = thisSearchArea.transform.position + offSet;
        }

        base.Enter();
    }

    public override void Update()
    {
        if (thisSearchArea.Searching)
        {
            agent.SetDestination(points[currentIndex]);

            Vector3 direction = points[currentIndex] - npc.transform.position;
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

            float distance = Vector2.Distance(npc.transform.position, points[currentIndex]);

            if (distance < 0.05)
            {
                if (currentIndex >= points.Length - 1)
                {
                    currentIndex = 0;
                }
                else
                {
                    currentIndex++;
                }
            }
        }
        else if (thisSearchArea.DoneSearching)
        {
            nextState = new Idle(npc, anim, player, idlePoints, pointOfView, searchArea, agent);
            stage = EVENT.EXIT;
        }
        else if (pointOfView.InRange || (!thisSearchArea.Searching && !thisSearchArea.DoneSearching))
        {
            nextState = new Engage(npc, anim, player, idlePoints, pointOfView, searchArea, agent);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        // anim.ResetTrigger("isSearching");
        base.Exit();
    }
}
