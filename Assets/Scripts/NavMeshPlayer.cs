using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPlayer : MonoBehaviour
{
    public Transform pointToGo;

    [SerializeField]
    private NavMeshAgent agent;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            agent.destination = pointToGo.transform.position;
        }
    }
}
