using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [Header("Camera Movement")]
    public Transform head; 
    public Transform body;

    [SerializeField] private float distance;
    private CameraController _cc;
    private NavMeshAgent _agent;

    public bool menu;

    void Start()
    {
        _cc = GetComponent<CameraController>();
        _agent = GetComponent<NavMeshAgent>();
        GetDistance(distance);
    }

    void Update()
    {
        if (menu)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);

            bool rDistance = _agent.remainingDistance > _agent.stoppingDistance;

            if (Physics.Raycast(rayOrigin, out RaycastHit hitInfo))
            {
                if(!rDistance)
                    _agent.isStopped = true;

                _agent.isStopped = false;
                _agent.SetDestination(hitInfo.point);

            }
        }

        if (Input.GetMouseButton(1))
            _cc.SetMove(true);
        else
            _cc.SetMove(false);
    }

    public void GetDistance(float d)
    {
        _agent.stoppingDistance = d;
    }
}
