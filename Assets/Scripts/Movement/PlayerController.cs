using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [Header("Camera Movement")]
    public Transform head; 
    public Transform body;

    private CameraController _cc;
    private NavMeshAgent _agent;

    public bool menu;

    void Start()
    {
        _cc = GetComponent<CameraController>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (menu)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
              /*  if(hitInfo.collider.gameObject.GetComponent<Interactable>())
                {

                }
                else*/
                    _agent.SetDestination(hitInfo.point);
            }
        }

        if (Input.GetMouseButton(1))
            _cc.SetMove(true);
        else
            _cc.SetMove(false);
    }
}
