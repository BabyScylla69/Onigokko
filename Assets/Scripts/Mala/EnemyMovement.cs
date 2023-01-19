using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] points;
    public Transform playerPos;
    private int destPoint = 0;
    private NavMeshAgent agent;
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float followSpeed;
    [SerializeField] private bool patrol = true;
    [SerializeField] private bool followPlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
        agent.speed = patrolSpeed;
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;

            destPoint = (Random.Range(0, points.Length)) % points.Length;
    }

    void Update()
    {
        if(followPlayer)
        {
            agent.destination = playerPos.position;
        }
        else if (!agent.pathPending && agent.remainingDistance < 2f)
        {
            if (patrol)
                GotoNextPoint();
            else
                agent.isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerController _pc))
        {
            agent.speed = followSpeed;
            patrol = false;
            followPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        patrol = true;
        followPlayer = false;
        agent.speed = patrolSpeed;
        GotoNextPoint();
    }
}