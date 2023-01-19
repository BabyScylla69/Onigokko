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
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if(patrol)
                GotoNextPoint();
            //else
                //perder
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerController _pc))
        {
            agent.destination = playerPos.position;
            agent.speed = followSpeed;
            patrol = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        patrol = true;
        agent.speed = patrolSpeed;
    }
}