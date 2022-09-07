using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnedEnemy : MonoBehaviour
{
    public float speed = 0.3f;

    Transform player;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;

        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (transform.eulerAngles.z + 90 >= 180 || transform.eulerAngles.z + 90 <= 0)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else if (transform.eulerAngles.z + 90 < 180 || transform.eulerAngles.z + 90 > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
