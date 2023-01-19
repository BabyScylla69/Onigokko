using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;

    private PlayerUI _pUI;

    void Start()
    {
        _pUI = GetComponent<PlayerUI>();
    }

    void Update()
    {
        _pUI.UpdateText(string.Empty);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out RaycastHit hitinfo, distance, mask))
        {
            if(hitinfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitinfo.collider.GetComponent<Interactable>();

                _pUI.UpdateText(interactable.proptMessage);

                if (Input.GetMouseButtonDown(0))
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
